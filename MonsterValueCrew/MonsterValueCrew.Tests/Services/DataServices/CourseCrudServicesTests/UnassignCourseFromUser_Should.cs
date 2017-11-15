using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterValueCrew.Tests.Services.DataServices.CourseCrudServicesTests
{
    [TestClass]
    public class UnasignCourseToUser_Should
    {
        [TestMethod]
        public async Task UnasaCourseToUser_WhenParametersAreCorrect()
        {
            //Arrange
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

            var dbContextMock = new Mock<ApplicationDbContext>();
            List<UserCourseAssignment> usersCoursesList = new List<UserCourseAssignment>();
            var usersCoursesDbSetMock = new Mock<DbSet<UserCourseAssignment>>().SetupData(usersCoursesList);
            dbContextMock.SetupGet<IDbSet<UserCourseAssignment>>(x => x.UserCourseAssignments).Returns(usersCoursesDbSetMock.Object);

            List<ApplicationUser> usersList = new List<ApplicationUser>() { user };
            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(usersList);
            dbContextMock.SetupGet<IDbSet<ApplicationUser>>(x => x.Users).Returns(usersDbSetMock.Object);

            List<Course> coursesList = new List<Course>() { course };
            var coursesDbSetMock = new Mock<DbSet<Course>>().SetupData(coursesList);
            dbContextMock.SetupGet<IDbSet<Course>>(x => x.Courses).Returns(coursesDbSetMock.Object);

            CourseCrudService courseService = new CourseCrudService(dbContextMock.Object);
            //Act
            await courseService.UnassignCourseFromUser(courseId,username);
            //Assert
            Assert.AreEqual(0, dbContextMock.Object.Users.Count<ApplicationUser>());

        }
    }
}
/* [TestClass]
    public class UnasignCourseToUser_Should
    {
        [TestMethod]
        public async Task UnasignCourseToUser_WhenParametersAreCorrect()
        {
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

            var dbContextMock = new Mock<ApplicationDbContext>();
            List<UserCourseAssignment> usersCoursesList = new List<UserCourseAssignment>();
            var usersCoursesDbSetMock = new Mock<DbSet<UserCourseAssignment>>().SetupData(usersCoursesList);
            dbContextMock.SetupGet<IDbSet<UserCourseAssignment>>(x => x.UserCourseAssignments).Returns(usersCoursesDbSetMock.Object);

            List<ApplicationUser> usersList = new List<ApplicationUser>() { user };
            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(usersList);
            dbContextMock.SetupGet<IDbSet<ApplicationUser>>(x => x.Users).Returns(usersDbSetMock.Object);

            List<Course> coursesList = new List<Course>() { course };
            var coursesDbSetMock = new Mock<DbSet<Course>>().SetupData(coursesList);
            dbContextMock.SetupGet<IDbSet<Course>>(x => x.Courses).Returns(coursesDbSetMock.Object);

            CourseCrudService courseService = new CourseCrudService(dbContextMock.Object);
            //Act
            await courseService.UnassignCourseFromUser(courseId,username);
            //Assert
            Assert.AreEqual(0, dbContextMock.Object.Users.Count<ApplicationUser>());

        }
*/