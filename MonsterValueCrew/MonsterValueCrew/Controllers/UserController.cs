using Bytes2you.Validation;
using MonsterValueCrew.Data;
using System.Web.Mvc;

namespace MonsterValueCrew.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "Database Context").IsNull().Throw();
            this.dbContext = context;
        }
        // GET: User
        public ActionResult AssignedCourses()
        {
            return View();
        }

        //public async Task<ActionResult> GetPendingCoursesByUserId(string userName)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    var user = await UserManager.FindByNameAsync(userName);
        //    var userId = user.Id;


        //}

        ////User/GetCourses
        //[HttpGet]
        //public JsonResult GetCourses()
        //{
        //    var jsonData = new
        //    {
        //        data = from emp in dbContext.Courses.ToList() select emp
        //    };
        //    return Json(jsonData, JsonRequestBehavior.AllowGet);

        //}

    }
}
