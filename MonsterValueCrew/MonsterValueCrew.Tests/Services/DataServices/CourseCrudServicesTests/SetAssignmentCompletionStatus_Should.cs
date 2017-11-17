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

namespace MonsterValueCrew.Tests.Services.DataServices.CourseCrudServicesTests
{
    [TestClass]
    public class SetAssignmentCompletionStatus_Should
    {
        [TestMethod]
        public async Task ChangeValueOnStatusPropertyToCompleted_WhenParametersAreCorrect()
        {
            //Arrange
            var dateTime = DateTime.Now;
            int courseId = 12;

            var coursesList = new List<Course>()
            {
                new Course()
                {
                    Id = courseId,
                    Name = "mockCourse1",
                    Description = "mockCourse1Description",
                    DateAdded = dateTime,
                    PassScore = 40
                }
            };

            var coursesDbSetMock = new Mock<DbSet<Course>>().SetupData(coursesList);

            var dbContextMock = new Mock<ApplicationDbContext>();
            dbContextMock.SetupGet(x => x.Courses).Returns(coursesDbSetMock.Object);

            string userName = "admin@test.com";
            string userId = "mockUserId";
            string firstName = "Marko";
            string lastName = "Markov";

            List<ApplicationUser> userList = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = userId,
                    UserName = userName,
                    FirstName = firstName,
                    LastName = lastName
                }
            };

            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(userList);
            dbContextMock.SetupGet(x => x.Users).Returns(usersDbSetMock.Object);

            var assignmentList = new List<UserCourseAssignment>()
            {
                new UserCourseAssignment()
                {
                    ApplicationUserId = userId,
                    CourseId = courseId,
                    DueDate = dateTime,
                    IsAssigned = true,
                    IsMandatory = true,
                    Status = StatusName.Pending
                }
            };

            var assignmentDbSetMock = new Mock<DbSet<UserCourseAssignment>>().SetupData(assignmentList);
            dbContextMock.SetupGet(x => x.UserCourseAssignments).Returns(assignmentDbSetMock.Object);


            //Act
            CourseCrudService services = new CourseCrudService(dbContextMock.Object);
            await services.SetAssignmentCompletionStatus(courseId, true);

            var expectedResult = dbContextMock.Object.UserCourseAssignments.Single();

            //Assert
            Assert.AreEqual(StatusName.Completed, expectedResult.Status);
            dbContextMock.Verify(m => m.SaveChangesAsync(), Times.Once);

        }


        [TestMethod]
        public async Task ChangeValueOnStatusPropertyToPending_WhenParametersAreCorrect()
        {
            //Arrange
            var dateTime = DateTime.Now;
            int courseId = 12;

            var coursesList = new List<Course>()
            {
                new Course()
                {
                    Id = courseId,
                    Name = "mockCourse1",
                    Description = "mockCourse1Description",
                    DateAdded = dateTime,
                    PassScore = 40
                }
            };

            var coursesDbSetMock = new Mock<DbSet<Course>>().SetupData(coursesList);

            var dbContextMock = new Mock<ApplicationDbContext>();
            dbContextMock.SetupGet(x => x.Courses).Returns(coursesDbSetMock.Object);

            string userName = "admin@test.com";
            string userId = "mockUserId";
            string firstName = "Marko";
            string lastName = "Markov";

            List<ApplicationUser> userList = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = userId,
                    UserName = userName,
                    FirstName = firstName,
                    LastName = lastName
                }
            };

            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(userList);
            dbContextMock.SetupGet(x => x.Users).Returns(usersDbSetMock.Object);

            var assignmentList = new List<UserCourseAssignment>()
            {
                new UserCourseAssignment()
                {
                    ApplicationUserId = userId,
                    CourseId = courseId,
                    DueDate = dateTime,
                    IsAssigned = true,
                    IsMandatory = true,
                    Status = StatusName.Pending
                }
            };

            var assignmentDbSetMock = new Mock<DbSet<UserCourseAssignment>>().SetupData(assignmentList);
            dbContextMock.SetupGet(x => x.UserCourseAssignments).Returns(assignmentDbSetMock.Object);


            //Act
            CourseCrudService services = new CourseCrudService(dbContextMock.Object);
            await services.SetAssignmentCompletionStatus(courseId, false);

            var expectedResult = dbContextMock.Object.UserCourseAssignments.Single();

            //Assert
            Assert.AreEqual(StatusName.Started, expectedResult.Status);
            dbContextMock.Verify(m => m.SaveChangesAsync(), Times.Once);
        }

    }
}
