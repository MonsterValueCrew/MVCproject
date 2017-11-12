using Bytes2you.Validation;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.Services.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace MonsterValueCrew.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;

        public AdminService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }
        
        // Ask BigVik how to make reusable, maybe string,reader, file or something else
        public void SaveCourse(HttpPostedFileBase json)
        {
            Guard.WhenArgument(json, "json").IsNull().Throw();

            if (json.InputStream.CanRead)
            {
                string jsonString = string.Empty;

                using (BinaryReader biteReader = new BinaryReader(json.InputStream))
                {
                    byte[] biteArray = biteReader.ReadBytes(json.ContentLength);
                    Guard.WhenArgument(biteArray, "No Json Data").IsNullOrEmpty().Throw();
                    jsonString = Encoding.UTF8.GetString(biteArray);
                }

                Course course = JsonConvert.DeserializeObject<Course>(jsonString);
                Guard.WhenArgument(course, "Course is Null").IsNull().Throw();
                this.context.Courses.Add(course);

                foreach (var question in course.Questions)
                {
                    question.CourseId = course.Id;
                    this.context.Questions.Add(question);
                }

                this.context.SaveChanges();
            }
        }
        public void SaveImagesToCourse(int courseId, List<ImageViewModel> imagesView)
        {
            foreach (var imageView in imagesView)
            {
                var image = new Image(imageView.Name, imageView.ImageInBase64, imageView.Order);
                Guard.WhenArgument(image, "Image is Null").IsNull().Throw();
                image.CourseId = courseId;
                this.context.Images.Add(image);
            }
            this.context.SaveChanges();
        }

    }
}
