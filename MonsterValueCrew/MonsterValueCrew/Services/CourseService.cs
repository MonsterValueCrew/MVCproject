using Bytes2you.Validation;
using MonsterValueCrew.Data;
using MonsterValueCrew.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using MonsterValueCrew.Data.Models;

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

        public string GetCourseName(int courseId)
        {
            // Get the assigned from admin course to user
            var assignedCourse = this.context.Courses.First(c => c.Id == courseId);
            var courseName = assignedCourse.Name;

            return courseName;
        }

        public IList<Image> GetImages(int courseId)
        {
            var images = this.context.Courses.First(c => c.Id == courseId).Images;

            return images.ToList();
        }
    }
}