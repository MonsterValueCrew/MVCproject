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
    public class CourseCrudService : ICourseCrudService
    {
        private readonly ApplicationDbContext dbContext;

        public CourseCrudService( ApplicationDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public async Task AddCourseObjectToDb(Course course)
        {
            Guard.WhenArgument(course, "course").IsNull().Throw();
            dbContext.Courses.Add(course);
            await Run();
             
        }

        public async Task AddCourseToDb(string name, string description,
            int passScore, bool isDeleted)
        {
            Guard.WhenArgument(name, "name").IsNull().Throw();
            Guard.WhenArgument(description, "description").IsNull().Throw();
            Guard.WhenArgument(passScore, "passScore").IsLessThanOrEqual(0).Throw();
            Guard.WhenArgument(isDeleted, "isDeleted").IsTrue().Throw();
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
        public async Task AddCourseToDb(Course courseToAdd)
        {
            dbContext.Courses.Add(courseToAdd);
            await Run();
        }

        public async Task AssignCourseToDepartment(int departmentID, int courseId,
            bool isAssigned, bool isMandatory, DateTime dueDate)
        {
            Guard.WhenArgument(departmentID, "departmentID").IsLessThanOrEqual(0).Throw();
            Guard.WhenArgument(courseId, "courseID").IsLessThanOrEqual(0).Throw();
            Guard.WhenArgument(isAssigned, "isAssignet").IsFalse().Throw();
            Guard.WhenArgument(isMandatory, "isMandatory").IsFalse().Throw();
            var users = this.dbContext.Users.Where(u => u.DepartmentId == departmentID);

            foreach (var user in users)
            {
                await AssignCourseToUser(user.UserName, courseId, true, isMandatory, dueDate);

            }

            await Run();
        }

        public async Task AssignCourseToUser(string userName, int courseId,
            bool isAssigned, bool isMandatory, DateTime dueDate)
        {
            Guard.WhenArgument(userName, "userName").IsNull().Throw();
            Guard.WhenArgument(courseId, "courseID").IsLessThanOrEqual(0).Throw();
            Guard.WhenArgument(isAssigned, "isAssignet").IsFalse().Throw();
            Guard.WhenArgument(isMandatory, "isMandatory").IsFalse().Throw();
           
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
            Guard.WhenArgument(courses, "courses").IsNull().Throw();
            return courses;
        }

        public Course GetCourseById(int courseId)
        {
            Guard.WhenArgument(courseId, "courseID").IsLessThanOrEqual(0).Throw();
            Course course = this.dbContext.Courses.Single(c => c.Id == courseId);

            return course;

        }

        public string GetCourseName(int courseId)
        {
            // Get the assigned from admin course to user
             Guard.WhenArgument(courseId, "courseID").IsLessThanOrEqual(0).Throw();
            var assignedCourse = this.dbContext.Courses.First(c => c.Id == courseId);
            var courseName = assignedCourse.Name;

            return courseName;
        }

        public IList<Image> GetImages(int courseId)
        {
            var images = this.dbContext.Courses.First(c => c.Id == courseId).Images;

            return images.ToList();
        }

        public IEnumerable<Course> GetCoursesByUserName(string username)
        {
            var user = GetUserByUserName(username);
            var courses = user.UserCourseAssignments
                .Select(a => a.Course)
                .Where(c => c.IsDeleted == false)
                .ToList();

            //IEnumerable<Course> courses = this.dbContext
            //    .UserCourseAssignments
            //    .Where(a => a.ApplicationUserId == user.Id)
            //    .Select(a => a.Course);
            Guard.WhenArgument(user, "user").IsNull().Throw();
            Guard.WhenArgument(courses, "courses").IsNull().Throw();

            return courses;
        }

        public IEnumerable<UserCourseAssignmentModel> GetInfoCoursesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public async Task UnassignCourseFromUser(int courseId, string username)
        {
           
            Guard.WhenArgument(courseId, "courseID").IsLessThanOrEqual(0).Throw();
            Guard.WhenArgument(username, "userName").IsNull().Throw();
            var assignment = this.dbContext.
                UserCourseAssignments.
                First(a => a.ApplicationUser.UserName == username && a.CourseId == courseId);

            assignment.IsAssigned = false;

            await Run();
        }

        private async Task Run()
        {
            await dbContext.SaveChangesAsync();
        }

        private ApplicationUser GetUserByUserName(string username)
        {
            var user = this.dbContext.Users.FirstOrDefault(u => u.UserName == username);
            Guard.WhenArgument(user, "this user doesn't exist").IsNull().Throw();

            return user;
        }

        private Course GetCourseByCourseID(int courseId)
        {
            var course = this.dbContext.Courses.First(c => c.Id == courseId);
            Guard.WhenArgument(course, "this course doesn't exist").IsNull().Throw();

            return course;
        }

    }
}
