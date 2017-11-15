using Bytes2you.Validation;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Models;
using System;
using System.Collections.Generic;
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
                .Select(v => new CourseViewModel()
                {
                    Id = v.Id,
                    Name = v.Name,
                    DateAdded = v.DateAdded,
                    Description = v.Description

                });


            return this.View(viewModel);
        }

        public ActionResult TakeCourse(int courseId)
        {
            IEnumerable<ImageViewModel> slides = services.GetAllSlidesForCourse(courseId)
                .Select(s => new ImageViewModel()
                {
                    ImageUrl = Convert.ToBase64String(s.ImageBinary)
                });

            return this.View(slides);
        }

        //public async Task<ActionResult> RenderImage(int id)
        //{
        //    Image image = await context.Images.FirstAsync(x => x.Id == id);

        //    byte[] currentImage = image.ImageInBase64;

        //    return File(currentImage, "image/png");
        //}



    }
}