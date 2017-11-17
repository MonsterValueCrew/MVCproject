using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.DataModels;
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
    public class GetUsersCourseAssignment_Should
    {
        [TestMethod]
        public void UserCourseAssignmentViewModel_WhenParametersAreCorrect()
        {
            //Arrange
            string userName = "admin1@admin.com";
            var dateTime = DateTime.Now;
            var dbContextMock = new Mock<ApplicationDbContext>();

            var course = new Course()
            {
                Id = 12,
                Name = "FakeName",
                Description = "FakeDescription",
                DateAdded = dateTime,
                PassScore = 40
            };
            var courseList = new List<Course>()
            {
                course
            };

            var coursesMock = new Mock<DbSet<Course>>().SetupData(courseList);

            dbContextMock.SetupGet(x => x.Courses).Returns(coursesMock.Object);

            var userList = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName=userName,
                    Id = "fakeID"
                }
            };

            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(userList);
            dbContextMock.SetupGet(x => x.Users).Returns(usersDbSetMock.Object);

            var userCourseAssignmentList = new List<UserCourseAssignment>()
            {
                new UserCourseAssignment()
                {
                    ApplicationUserId = "fakeID",
                    CourseId = 12,
                    Course = course,
                    AssignmentDate = dateTime,
                    CompletionDate = dateTime,
                    DueDate = dateTime,
                    IsAssigned = true,
                    Id = 1,
                    IsMandatory = true,
                    Status = StatusName.Pending
                }
            };
            var UserCourseAssignmentDbSetMock = new Mock<DbSet<UserCourseAssignment>>()
                .SetupData(userCourseAssignmentList);

            dbContextMock.SetupGet(x => x.UserCourseAssignments)
                .Returns(UserCourseAssignmentDbSetMock.Object);

            var UserCourseAssignmentViewModelList = new List<UserCourseAssignmentViewModel>()
            {
                new UserCourseAssignmentViewModel()
                {
                    AssignmentDate = dateTime,
                    CompletionDate = dateTime,
                    DueDate = dateTime,
                    IsMandatory = true,
                    Name = "FakeName",
                    Status = StatusName.Pending
                }
            };


            //Act
            var courseServices = new CourseCrudService(dbContextMock.Object);
            var expectedResultObject = UserCourseAssignmentViewModelList.Single();
            var resultObject = courseServices.GetUsersCourseAssignment(userName).Single();

            //Assert
            Assert.AreEqual(expectedResultObject.Name, resultObject.Name);
            Assert.AreEqual(expectedResultObject.AssignmentDate, resultObject.AssignmentDate);
            Assert.AreEqual(expectedResultObject.CompletionDate, resultObject.CompletionDate);
            Assert.AreEqual(expectedResultObject.DueDate, resultObject.DueDate);
            Assert.AreEqual(expectedResultObject.IsMandatory, resultObject.IsMandatory);
            Assert.AreEqual(expectedResultObject.Status, resultObject.Status);

        }

    }
}
