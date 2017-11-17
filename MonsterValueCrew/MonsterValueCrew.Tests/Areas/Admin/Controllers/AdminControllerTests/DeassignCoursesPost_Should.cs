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
    public class DeassignPost_Should
    {
        [TestMethod]
        public void RedirectsToAction()
        {
            //Arrange
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(userStore.Object);
            var adminServiceMock = new Mock<IAdminService>();
            var dbContextMock = new Mock<ApplicationDbContext>();
            var courseServiceMock = new Mock<ICourseCrudService>();

            var model = new DeassignViewModel();
            var models = new List<DeassignViewModel>() { model };
            var applicationUserManagerMock = new Mock<ApplicationUserManager>(userStore.Object);

            var controller = new AdminController(
                                    userManagerMock.Object,
                                    dbContextMock.Object, 
                                    adminServiceMock.Object, 
                                    courseServiceMock.Object);

            //Act & Assert
            controller
                .WithCallTo(x => x.DeassignCourses(models))
                .ShouldRedirectTo(x => x.DeassignCourses());

        }

        [TestMethod]
        public void InvokesMethodInDbServices()
        {
            //Arrange
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(userStore.Object);
            var adminServiceMock = new Mock<IAdminService>();
            var dbContextMock = new Mock<ApplicationDbContext>();
            var courseServiceMock = new Mock<ICourseCrudService>();

            var model = new DeassignViewModel();
            var models = new List<DeassignViewModel>()
            {
                model
            };
            var applicationUserManagerMock = new Mock<ApplicationUserManager>(userStore.Object);

            var controller = new AdminController(
                                    userManagerMock.Object, 
                                    dbContextMock.Object, 
                                    adminServiceMock.Object, 
                                    courseServiceMock.Object);

            //Act
            controller.DeassignCourses(models);


            // Assert
            adminServiceMock.Verify(x => x.DeleteCourseStates(models), Times.Once);

        }

    }
}
