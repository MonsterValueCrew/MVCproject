using Bytes2you.Validation;
using MonsterValueCrew.Data;
using MonsterValueCrew.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonsterValueCrew.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly ICourseService courseService;

        public CoursesController(ApplicationUserManager userManager, 
            ApplicationDbContext dbContext, 
            ICourseService courseService)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();
            Guard.WhenArgument(courseService, "courseService").IsNull().Throw();

            this.userManager = userManager;
            this.dbContext = dbContext;
            this.courseService = courseService;
        }


        // GET: Courses
        public ActionResult AllCourses()
        {
            return View();
        }
    }
}