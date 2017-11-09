using MonsterValueCrew.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterValueCrew.Data.DataModels;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.Data;
using Bytes2you.Validation;

namespace MonsterValueCrew.DataServices
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationUserManager userManager;
        private readonly ApplicationDbContext dbContext;

        public CourseService(ApplicationUserManager userManager, ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;

            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();
        }

        public async Task AddCourseObjectToDb(Course course)
        {
            dbContext.Courses.Add(course);

            await Run();
        }

        public async Task AddCourseToDb(string name, string description,
            int passScore, bool isDeleted)
        {
            Course course = new Course
            {
                Name = name,
                Description = description,
                DateAdded = DateTime.Now,
                PassScore = passScore,
                IsDeleted = false
            };

            this.dbContext.Courses.Add(course);

            await Run();
        }

        public Task AssignCourseToDepartment(int departmentID, int courseId,
            bool isAssigned, bool isMandatory, DateTime dueDate)
        {
            throw new NotImplementedException();

        }

        public async Task AssignCourseToUser(string userName, int courseId,
            bool isAssigned, bool isMandatory, DateTime dueDate)
        {
            var user = GetUserByUserName(userName);
            Course course = GetCourseByCourseID(courseId);

            UserCourseAssignment assignment = new UserCourseAssignment
            {
                Course = course,
                ApplicationUser = user,
                IsAssigned = true,
                IsMandatory = isMandatory,
                DueDate = dueDate
            };

            this.dbContext.UserCourseAssignments.Add(assignment);

            await Run();

        }

        public IEnumerable<Course> GetAllCourses()
        {
            IEnumerable<Course> courses = this.dbContext.Courses.ToList();

            return courses;
        }

        public Course GetCourseById(int courseId)
        {
            Course course = this.dbContext.Courses.Single(c => c.Id == courseId);

            return course;

        }

        public IEnumerable<Course> GetCoursesByUserName(string username)
        {
            var user = GetUserByUserName(username);
            var courses = user.UserCourseAssignments.Select(a => a.Course).ToList();
            //IEnumerable<Course> courses = this.dbContext
            //    .UserCourseAssignments
            //    .Where(a => a.ApplicationUserId == user.Id)
            //    .Select(a => a.Course);

            return courses;
        }

        public IEnumerable<UserCourseAssignmentModel> GetInfoCoursesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task UnassignCourseFromUser(int courseId, string username)
        {
            throw new NotImplementedException();
        }

        private async Task Run()
        {
            await dbContext.SaveChangesAsync();
        }

        private ApplicationUser GetUserByUserName(string username)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.UserName == username);
            Guard.WhenArgument(user, "this user doesn't exist").IsNull().Throw();

            return user;
        }

        private Course GetCourseByCourseID(int courseId)
        {
            var course = dbContext.Courses.First(c => c.Id == courseId);
            Guard.WhenArgument(course, "this course doesn't exist").IsNull().Throw();

            return course;
        }


    }
}
