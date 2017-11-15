using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.DataModels;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Services.Contracts;
using Moq;
using TestStack.FluentMVCTesting;

namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class AllUser_Should
    {
        [TestMethod]
        public void ReturnDefaultViewWithCorrectViewModel()
        {
            //Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var dbContextMock = new Mock<ApplicationDbContext>();
            var adminServiceMock = new Mock<IAdminService>();
            var courseCrudServiceMock = new Mock<ICourseCrudService>();
            
            var resultViewModel = new UploadJSONViewModel();
            
            AdminController controller = new AdminController(userManagerMock.Object, dbContextMock.Object, adminServiceMock.Object, courseCrudServiceMock.Object);

            //Act & Assert
            controller
                .WithCallTo(c => c.UploadCourses())
                .ShouldRenderDefaultView()
                .WithModel<UploadJSONViewModel>();
        }
    }
}
