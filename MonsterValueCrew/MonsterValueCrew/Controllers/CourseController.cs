using Bytes2you.Validation;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.Models;
using MonsterValueCrew.Services.Contracts;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MonsterValueCrew.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService services;
        private readonly ApplicationDbContext context;

        public CourseController(ICourseService services, ApplicationDbContext context)
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
    }
}