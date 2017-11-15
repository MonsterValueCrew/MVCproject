using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterValueCrew.Tests.Services.DataServices.CourseServicesTests
{
    [TestClass]
    public class AssignCourseToUser_Should
    {
        [TestMethod]
        public async Task AddCourseToUser_WhenParametersAreCorrect()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();


            var usersCoursesList = new List<UserCourseAssignment>();
            var usersCoursesDbSetMock = new Mock<DbSet<UserCourseAssignment>>().SetupData(usersCoursesList);

            dbContextMock.SetupGet(x => x.UserCourseAssignments).Returns(usersCoursesDbSetMock.Object);

            string username = "username";
            int courseId = 4;
            bool isAssigned = true;
            bool IsMandatory = true;
            DateTime date = DateTime.Now;

            var user = new ApplicationUser()
            {
                Id = "userid",
                UserName = username
            };
            var course = new Course()
            {
                Id = courseId,
                Description = "description",
                Name = "name",
                DateAdded = date,
                PassScore = 30
            };

            var usersList = new List<ApplicationUser>() { user };
            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(usersList);
            dbContextMock.SetupGet(x => x.Users).Returns(usersDbSetMock.Object);

            var coursesList = new List<Course>() { course };
            var coursesDbSetMock = new Mock<DbSet<Course>>().SetupData(coursesList);
            dbContextMock.SetupGet(x => x.Courses).Returns(coursesDbSetMock.Object);

            CourseCrudService courseService = new CourseCrudService(dbContextMock.Object);
            //Act

            await courseService.AssignCourseToUser(username, courseId, isAssigned, IsMandatory, date);

            //Assert
            Assert.AreEqual(1, dbContextMock.Object.Users.Count());
            dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);

        }

        [TestMethod]
        public async Task ThrowException_WhenCourseIdIsInvalid()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            int courseId = -1;
            
            string username = "username";
            bool isAssigned = true;
            bool IsMandatory = true;
            DateTime date = DateTime.Now;

            var user = new ApplicationUser()
            {
                Id = "userid",
                UserName = username
            };

            var usersCoursesList = new List<UserCourseAssignment>();

            var usersCoursesDbSetMock = new Mock<DbSet<UserCourseAssignment>>().SetupData(usersCoursesList);
            dbContextMock.SetupGet(x => x.UserCourseAssignments).Returns(usersCoursesDbSetMock.Object);

            var usersList = new List<ApplicationUser>()
            {
                user
            };

            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(usersList);

            dbContextMock.SetupGet(x => x.Users).Returns(usersDbSetMock.Object);

            CourseCrudService courseService = new CourseCrudService(dbContextMock.Object);

            //Act && Assert

            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => courseService.AssignCourseToUser(username, courseId, isAssigned, IsMandatory, date));

        }

    }
}
