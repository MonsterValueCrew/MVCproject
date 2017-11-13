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
        public ActionResult TakeCourse(TakeCourseVIewModel viewModel)
        {
            int courseId = 1;
            var course = services.GetCourseById(courseId);
            var images = services.GetImages(courseId);

            viewModel.Name = course.Name;
            viewModel.Images = course.Images;

            return View(viewModel);
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
                .Select(v => new AllCoursesViewModel()
                {
                    Id = v.Id,
                    Name = v.Name,
                    DueDate = v.DateAdded,
                    Description = v.Description
                    
                });


            return this.View(viewModel);
        }


    }
}