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
using TestStack.FluentMVCTesting;

namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class Assignment_Should
    {
        [TestMethod]
        public void ReturnCorrectView_WhenParametersAreCorrect()
        {
            //Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var dbContextMock = new Mock<ApplicationDbContext>();
            var adminServiceMock = new Mock<IAdminService>();
            var courseCrudServiceMock = new Mock<ICourseCrudService>();

            var userList = new List<UserViewModel>()
            {
                new UserViewModel()
                {
                    UserName = "Programming",
                    Id = "Pesho",
                    IsSelected = true
                },
                new UserViewModel()
                {
                    UserName = "Programming",
                    Id = "Gosho"
                }
            };

            var coursesList = new List<CourseViewModel>()
            {
                new CourseViewModel()
                {
                    Name = "Programming",
                    Id = 0,
                    IsSelected = true
                },
                new CourseViewModel()
                {
                    Name = "Programming",
                    Id = 1
                }
            };

            var resultViewModel = new UserCourseAssignmentViewModel()
            {
                Users = userList,
                Courses = coursesList
            };

            var controller = new AdminController(userManagerMock.Object, dbContextMock.Object, adminServiceMock.Object, courseCrudServiceMock.Object);


            //Act & Assert
            controller
                .WithCallTo(x => x.Assignment(resultViewModel))
                .ShouldRenderDefaultView();
        }
    }
}
