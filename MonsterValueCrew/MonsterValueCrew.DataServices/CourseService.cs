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

        public Task AddCourseObjectToDb(Course course)
        {
            throw new NotImplementedException();
        }

        public Task AddCourseToDb(string description, DateTime DateAdded, int passScore, bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public Task AssignCourseToDepartment(int departmentID, int courseId, bool isAssigned, bool isMandatory, DateTime dueDate)
        {
            throw new NotImplementedException();
        }

        public Task AssignCourseToUser(string userName, int courseId, bool isAssigned, bool isMandatory, DateTime dueDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Course GetCourseById(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCourseAssignmentModel> GetInfoCoursesForUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
