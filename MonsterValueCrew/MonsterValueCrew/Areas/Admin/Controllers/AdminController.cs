using Bytes2you.Validation;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

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
                .Select(UserViewModel.Create)
                .ToList();

            return this.View(userViewModel);
        }
        public ActionResult UploadCourses()
        {
            var jsonModel = new UploadJSONViewModel();

            return this.View(jsonModel);
        }

        [HttpPost]
        public async Task<ActionResult> UploadCourses(UploadJSONViewModel files)
        {
            UploadJSONViewModel file = new UploadJSONViewModel();
            file.Json = Request.Files["file"];

            if (ModelState.IsValid)
            {
                Guard.WhenArgument(file, "file").IsNull().Throw();
                Guard.WhenArgument(file.Json, "Json File").IsNull().Throw();
                Guard.WhenArgument(file.Json.ContentLength, "Lenght")
                    .IsLessThanOrEqual(0).Throw();

                var jsonString = this.adminService.ReadJsonFile(file.Json);
                var course = this.adminService.DeserializeJsonString(jsonString);
                await this.adminService.SaveCourse(course);

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

            await this.dbContext.SaveChangesAsync();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assignment(UserCourseAssignmentViewModel userCourseAssignmentViewModel)
        {   
            Guard.WhenArgument(userCourseAssignmentViewModel, "userCourseAssignmentViewModel").IsNull().Throw();

            userCourseAssignmentViewModel.Users = userCourseAssignmentViewModel.Users.Where(u => u.IsSelected).ToList();
            userCourseAssignmentViewModel.Courses = userCourseAssignmentViewModel.Courses.Where(u => u.IsSelected).ToList();

            return this.View(userCourseAssignmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AssignCourses(UserCourseAssignmentViewModel userCourseAssignmentViewModel)
        {
            Guard.WhenArgument(userCourseAssignmentViewModel, "userCourseAssignmentViewModel").IsNull().Throw();

            var userIds = userCourseAssignmentViewModel.Users.Select(u => u.Id).ToArray();
            var courseIds = userCourseAssignmentViewModel.Courses.Select(c => c.Id).ToArray();

            var users = dbContext.Users.Where(u => userIds.Contains(u.Id)).ToList();
            var courses = dbContext.Courses.Where(c => courseIds.Contains(c.Id)).ToList();

            
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < courses.Count; j++)
                { 
                    await this.courseCrudService
                        .AssignCourseToUser(users[i].UserName,
                                            courses[j].Id,
                                            true,
                                            userCourseAssignmentViewModel.IsMandatory,
                                            userCourseAssignmentViewModel.DueDate);
                }
            }

            return RedirectToAction("AssignCourses");
        }

        public ActionResult DisplayCourses(string username)
        {
            var user = this.courseCrudService.GetUserByUserName(username);
            var userViewModel = UserViewModel.Create.Compile()(user);

            ViewBag.PendingCourses = GetUserCourseAssignmentByStatusName(
                user.UserName,
                StatusName.Pending);

            ViewBag.StartedCourses = GetUserCourseAssignmentByStatusName(
                 user.UserName,
                 StatusName.Started);

            ViewBag.CompletedCourses = GetUserCourseAssignmentByStatusName(
                user.UserName,
                StatusName.Completed);


            return this.PartialView("_DisplayCourses", userViewModel);
        }
        private IEnumerable<UserCourseAssignmentViewModel> GetUsersCourseAssignment(string username)
        {
            var user = this.courseCrudService.GetUserByUserName(username);

            var resultList = dbContext.UserCourseAssignments
                .Where(u => u.ApplicationUserId == user.Id)
                .Select(x => new UserCourseAssignmentViewModel()
                {
                    Name = x.Course.Name,
                    Status = x.Status,
                    AssignmentDate = x.AssignmentDate,
                    DueDate = x.DueDate,
                    IsMandatory = x.IsMandatory,
                    CompletionDate = x.CompletionDate
                })
                .ToList();

            return resultList;
        }
        private IEnumerable<UserCourseAssignmentViewModel> GetUserCourseAssignmentByStatusName(string username, StatusName status)
        {
            var completedCourses = this.GetUsersCourseAssignment(username)
                .Where(c => c.Status == status)
                .ToList();
            Guard.WhenArgument(completedCourses.Count, "Number Of Completed Courses").IsLessThanOrEqual(0).Throw();
          
            return completedCourses;
        }
    }
}

