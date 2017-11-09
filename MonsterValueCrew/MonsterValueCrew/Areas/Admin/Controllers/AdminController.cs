using Bytes2you.Validation;
using MonsterValueCrew.Areas.Admin.Models;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.Services.Contracts;
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
        private readonly ICourseService courseService;

        public AdminController(ApplicationUserManager userManager, ApplicationDbContext dbContext)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public AdminController(ApplicationUserManager userManager, ApplicationDbContext dbContext, ICourseService courseService) : this(userManager, dbContext)
        {
            Guard.WhenArgument(courseService, "courseService").IsNull().Throw();
            this.courseService = courseService;
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
        public ActionResult UploadCourses(UploadJSONViewModel file)
        {
            if (ModelState.IsValid)
            {
                Guard.WhenArgument(file, "file").IsNull().Throw();
                Guard.WhenArgument(file.Json, "Json File").IsNull().Throw();
                Guard.WhenArgument(file.Json.ContentLength, "Lenght")
                    .IsLessThanOrEqual(0).Throw();
                
                this.courseService.SaveCourse(file.Json);

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

    }
}