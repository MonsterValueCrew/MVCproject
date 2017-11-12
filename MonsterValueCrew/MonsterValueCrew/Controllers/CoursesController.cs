using Bytes2you.Validation;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MonsterValueCrew.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseCrudService services;
        private readonly ApplicationDbContext context;

        public CoursesController(ICourseCrudService services, ApplicationDbContext context)
        {
            Guard.WhenArgument(services, "services").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.services = services;
            this.context = context;
        }

        // GET: Course
        public ActionResult TakeCourse(TakeACourseViewModel model)
        {
            int courseId = 1;
            var course = this.context.Courses.First(c => c.Id == courseId);
            var images = this.services.GetImages(courseId);

            model.Name = course.Name;

            model.Images = images;

            return View(model);
        }

        public async Task<ActionResult> RenderImage(int id)
        {
            Image image = await context.Images.FirstAsync(x => x.Id == id);

            byte[] currentImage = image.ImageInBase64;

            return File(currentImage, "image/png");
        }

        public ActionResult AllCourses()
        {

            var viewModel = services.GetCoursesByUserName(this.User.Identity.Name)
                .Select(v => new AllMyCoursesViewModel()
                {
                    Name = v.Name,
                    DueDate = v.DateAdded
                });


            return this.View(viewModel);
        }


    }
}