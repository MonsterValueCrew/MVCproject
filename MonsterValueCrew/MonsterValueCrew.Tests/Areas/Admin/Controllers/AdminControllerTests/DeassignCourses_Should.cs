using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.DataModels;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Services.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class Deassign_Should
    {
        [TestMethod]
        public void ReturnDefaultViewWithModel()
        {
            //Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var adminServiceMock = new Mock<IAdminService>();
            var dbContextMock = new Mock<ApplicationDbContext>();
            var courseService = new Mock<ICourseCrudService>();
            var model = new DeassignViewModel();
            var models = new List<DeassignViewModel>() { model };
            var userCourseAssignmentsList = new List<UserCourseAssignment>() { new UserCourseAssignment() { Id = 1 } };

            var controller = new AdminController(userManagerMock.Object, dbContextMock.Object, adminServiceMock.Object, courseService.Object);

            adminServiceMock.Setup(x => x.GetAllUserCourseAssignments()).Returns(userCourseAssignmentsList);

            //Act & Assert
            controller
                .WithCallTo(x => x.DeassignCourses())
                .ShouldRenderDefaultView()
                .WithModel<List<DeassignViewModel>>(x => x.First().userCourseAssignmentMiddleMan.Id == userCourseAssignmentsList.First().Id);
        }
    }
}
