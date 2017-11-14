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

        public ActionResult AllCourses()
        {
            var viewModel = this.services.GetCoursesByUserName(this.User.Identity.Name)
                .Select(v => new TakeCourseVIewModel()
                {
                    Id = v.Id,
                    Name = v.Name,
                    DateAdded = v.DateAdded,
                    Description = v.Description

                });


            return this.View(viewModel);
        }

        public ActionResult TakeCourse(TakeCourseVIewModel viewModel)
        {
            //how to put the Id of the course here? is it fine that way: int courseId = viewModel.Id?
            //No! It says '0'!
            int courseId = 6;
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



    }
}