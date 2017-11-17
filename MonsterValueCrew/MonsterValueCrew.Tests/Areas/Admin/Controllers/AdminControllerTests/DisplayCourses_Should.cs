using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Services.Contracts;
using Moq;
using TestStack.FluentMVCTesting;

namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
   public class DisplayCourses_Should
    {
        [TestMethod]
        public void ReturnCorrectViewWhenCalled()
        {
            //Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var dbContextMock = new Mock<ApplicationDbContext>();
            var adminServiceMock = new Mock<IAdminService>();
            var courseCrudServiceMock = new Mock<ICourseCrudService>();

            var controller = new AdminController(
                                    userManagerMock.Object,
                                    dbContextMock.Object,
                                    adminServiceMock.Object,
                                    courseCrudServiceMock.Object);
            var username = "gosho";
            var user = new ApplicationUser()
            {
                UserName = username
            };
            courseCrudServiceMock.Setup(c => c.GetUserByUserName(username)).Returns(user);

            // Act & Assert

            controller
                .WithCallTo(x => x.DisplayCourses(username))
                .ShouldRenderPartialView("_DisplayCourses");
            
        }
    }
}
