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
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext context;
        private int currentCourseId;

        public CourseService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public int GetCourseById()
        {
            return this.currentCourseId;
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
                    jsonString = Encoding.UTF8.GetString(biteArray);
                }

                Course course = JsonConvert.DeserializeObject<Course>(jsonString);
                
                this.context.Courses.Add(course);

                foreach (var question in course.Questions)
                {
                    question.CourseId = course.Id;
                    this.context.Questions.Add(question);
                }

                this.context.SaveChanges();
                this.currentCourseId = course.Id;
            }
        }
    }
}
