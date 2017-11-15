using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.Controllers;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Services;
using MonsterValueCrew.Services.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            var usersSetMock = new List<UserViewModel>().Select(u => new UserViewModel()
            {
                UserName = u.UserName,
                Id = u.Id
            }).ToList();

            var courses = new List<Course>()
            {
                new Course() { Name = "Programming", Id = 0 },
                new Course() { Name = "Programming", Id = 1 }
            };
            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);
            dbContextMock.SetupGet(c => c.Courses).Returns(coursesSetMock.Object);

            var coursesViewMock = new List<CourseViewModel>().Select(u => new CourseViewModel()
            {
                Name = u.Name,
                Id = u.Id
            }).ToList();

            
            var resultViewModel = new UserCourseAssignmentViewModel()
            {
                Users = usersSetMock,
                Courses = coursesViewMock
            };
            
            

            AdminController controller = new AdminController(userManagerMock.Object, dbContextMock.Object, adminServiceMock.Object, courseCrudServiceMock.Object);

            //Act & Assert
            controller
                .WithCallTo(c => c.AssignCourses())
                .ShouldRenderDefaultView()
                .WithModel<UserCourseAssignmentViewModel>(v =>
                {
                        Assert.AreEqual(resultViewModel, v);
                });


        }
    }
}
