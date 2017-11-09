using Bytes2you.Validation;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.Services.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace MonsterValueCrew.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext context;

        public CourseService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public Course GetCourseById(int id)
        {
            Guard.WhenArgument(id, "id").IsGreaterThanOrEqual(0).Throw();
            var course = this.context.Courses.Find(id);
            return course;
        }

        public void SaveCourse(HttpPostedFileBase json)
        {
            Guard.WhenArgument(json, "json").IsNull().Throw();
            if (json.InputStream.CanRead)
            {
                string jsonString = string.Empty;

                using (BinaryReader biteReader = new BinaryReader(json.InputStream))
                {
                    byte[] biteArray = biteReader.ReadBytes(json.ContentLength);
                    jsonString = System.Text.Encoding.UTF8.GetString(biteArray);
                }

                Course course = JsonConvert.DeserializeObject<Course>(jsonString);
                
                this.context.Courses.Add(course);

                foreach (var question in course.Questions)
                {
                    question.CourseId = course.Id;
                    this.context.Questions.Add(question);
                }
                this.context.SaveChanges();
            }
        }

        public byte[] ImageToByteArray(HttpPostedFileBase image)
        {
            Guard.WhenArgument(image, "image").IsNull().Throw();
            
            using (MemoryStream ms = new MemoryStream())
            {
                image.InputStream.Seek(0, SeekOrigin.Begin);
                image.InputStream.CopyTo(ms);
                byte[] array = ms.GetBuffer();
                return array;
            }
        }

        public void SaveSlidesToCourse(int courseId, List<ImageViewModel> imagesView)
        {
            Guard.WhenArgument(courseId, "courseId").IsGreaterThanOrEqual(0).Throw();
            Guard.WhenArgument(imagesView, "imagesView").IsNullOrEmpty().Throw();

            foreach (var imageView in imagesView)
            {
                var image = new Image(imageView.Name, imageView.ImageInBase64, imageView.Order);

                image.CourseId = courseId;
                this.context.Images.Add(image);
            }
            this.context.SaveChanges();
        }
    }
}
