using Bytes2you.Validation;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.Services.Contracts;
using MonsterValueCrew.DataServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MonsterValueCrew.DataServices.Interfaces;

namespace MonsterValueCrew.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly IAdminService adminService;
        private readonly ICourseCrudService courseCrudService;

        public AdminController(ApplicationUserManager userManager, ApplicationDbContext dbContext, IAdminService adminService, ICourseCrudService courseCrudService)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();

            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();
            Guard.WhenArgument(adminService, "adminService").IsNull().Throw();
            Guard.WhenArgument(courseCrudService, "courseCrudService").IsNull().Throw();
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.adminService = adminService;
            this.courseCrudService = courseCrudService;
        }


        public ActionResult AllUsers()
        {
            var userViewModel = this.dbContext
                .Users
                .Select(UserViewModel.Create).ToList();

            return this.View(userViewModel);
        }
        public ActionResult UploadCourses()
        {
            var jsonModel = new UploadJSONViewModel();

            return this.View(jsonModel);
        }

        [HttpPost]
        public ActionResult UploadCourses(UploadJSONViewModel files)
        {
            UploadJSONViewModel file = new UploadJSONViewModel();
            file.Json = Request.Files["file"];

            if (ModelState.IsValid)
            {
                Guard.WhenArgument(file, "file").IsNull().Throw();
                Guard.WhenArgument(file.Json, "Json File").IsNull().Throw();
                Guard.WhenArgument(file.Json.ContentLength, "Lenght")
                    .IsLessThanOrEqual(0).Throw();

                this.adminService.SaveCourse(file.Json);

                return this.View();
            }
            return this.View(file);
        }

        public async Task<ActionResult> EditUser(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userViewModel = UserViewModel.Create.Compile()(user);

            userViewModel.IsAdmin = await this.userManager.IsInRoleAsync(user.Id, "Admin");

            return this.PartialView("_EditUser", userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(UserViewModel userViewModel)
        {
            Guard.WhenArgument(userViewModel, "userViewModel").IsNull().Throw();

            if (userViewModel.IsAdmin)
            {
                await this.userManager.AddToRoleAsync(userViewModel.Id, "Admin");
            }
            else
            {
                await this.userManager.RemoveFromRoleAsync(userViewModel.Id, "Admin");
            }

            var user = await this.userManager.FindByNameAsync(userViewModel.UserName);
            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;

            dbContext.SaveChanges();

            return RedirectToAction("AllUsers");
        }


        [HttpGet]
        public ActionResult AssignCourses()
        {
            var users = this.userManager
                .Users
                .Select(u => new UserViewModel()
                {
                    UserName = u.UserName,
                    Id = u.Id
                }).ToList();

            var courses = this.dbContext
                .Courses
                .Select(c => new CourseViewModel()
                {
                    Name = c.Name,
                    Id = c.Id
                })
                .ToList();

            var userCourseAssignmentViewModel = new UserCourseAssignmentViewModel()
            {
                Courses = courses,
                Users = users
            };

            return this.View(userCourseAssignmentViewModel);
        }

        [HttpGet]
        public ActionResult Assignment(UserCourseAssignmentViewModel userCourseAssignmentViewModel)
        {
            Guard.WhenArgument(userCourseAssignmentViewModel, "userCourseAssignmentViewModel").IsNull().Throw();

            return this.View(userCourseAssignmentViewModel);
        }

        [HttpPost]
        public ActionResult SubmitAssignments(UserCourseAssignmentViewModel userCourseAssignmentViewModel)
        {
            Guard.WhenArgument(userCourseAssignmentViewModel, "userCourseAssignmentViewModel").IsNull().Throw();

            var userIds = userCourseAssignmentViewModel.Users.Select(y => y.Id).ToArray();
            var courseIds = userCourseAssignmentViewModel.Courses.Select(cr => cr.Id).ToArray();

            var users = dbContext.Users.Where(x => userIds.Contains(x.Id)).ToList();
            var courses = dbContext.Courses.Where(c => courseIds.Contains(c.Id)).ToList();


            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < courses.Count; j++)
                { 
                    this.courseCrudService
                        .AssignCourseToUser(users[i].UserName,
                                            courses[j].Id,
                                            true,
                                            userCourseAssignmentViewModel.IsMandatory,
                                            userCourseAssignmentViewModel.DueDate);
                }
            }

            return RedirectToAction("AssignCourses");
        }
    }
}