using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.DataModels;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Services.Contracts;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using TestStack.FluentMVCTesting;

namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class AssignCoursesGet_Should
    {
        [TestMethod]
        public void ReturnUserCourseAssignmentViewModel()
        {
            //Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var dbContextMock = new Mock<ApplicationDbContext>();
            var adminServiceMock = new Mock<IAdminService>();
            var courseCrudServiceMock = new Mock<ICourseCrudService>();

            var users = new List<ApplicationUser>()
            {
                new ApplicationUser() {UserName = "firstUser", Id = "Pesho"  },
                new ApplicationUser() {UserName = "secondUser", Id = "Gosho"}
            };

            var courses = new List<Course>()
            {
                new Course() { Name = "Programming", Id = 0 },
                new Course() { Name = "Programming", Id = 1 }
            };

            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);
            dbContextMock.SetupGet(c => c.Courses).Returns(coursesSetMock.Object);

            var usersSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);
            dbContextMock.SetupGet(c => c.Users).Returns(usersSetMock.Object);

            var controller = new AdminController(
                                                userManagerMock.Object,
                                                dbContextMock.Object, 
                                                adminServiceMock.Object, 
                                                courseCrudServiceMock.Object);

            //Act & Assert
            controller
                .WithCallTo(c => c.AssignCourses())
                .ShouldRenderDefaultView()
                .WithModel<UserCourseAssignmentViewModel>(v =>
                {
                    for (int i = 0; i < v.Users.Count; i++)
                    {
                        Assert.AreEqual(users[i].Id, v.Users[i].Id);
                        Assert.AreEqual(users[i].UserName, v.Users[i].UserName);
                    }

                    for (int i = 0; i < v.Courses.Count; i++)
                    {
                        Assert.AreEqual(courses[i].Id, v.Courses[i].Id);
                        Assert.AreEqual(courses[i].Name, v.Courses[i].Name);
                    }
                });
        }
    }
}
