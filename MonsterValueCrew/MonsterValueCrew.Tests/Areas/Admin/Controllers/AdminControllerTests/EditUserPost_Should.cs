//using Microsoft.AspNet.Identity;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MonsterValueCrew.Areas.Admin.Controllers;
//using MonsterValueCrew.Data;
//using MonsterValueCrew.Data.DataModels;
//using MonsterValueCrew.Data.Models;
//using MonsterValueCrew.DataServices.Interfaces;
//using MonsterValueCrew.Services.Contracts;
//using Moq;
//using System.Threading.Tasks;
//using TestStack.FluentMVCTesting;

//namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
//{
//    [TestClass]
//    public class EditUserPost_Should
//    {
//        [TestMethod]
//        public void ReturnPartialView_WhenParametersAreCorrect()
//        {
//            //Arrange
//            var storeMock = new Mock<IUserStore<ApplicationUser>>();
//            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
//            var dbContextMock = new Mock<ApplicationDbContext>();
//            var adminServiceMock = new Mock<IAdminService>();
//            var courseCrudServiceMock = new Mock<ICourseCrudService>();

//            var username = "BestUserEvah";
//            var user = new ApplicationUser()
//            {
//                UserName = username
//            };
//            userManagerMock.Setup(u => u.FindByNameAsync(username)).Returns(Task.FromResult(user));

//            var userViewModel = new UserViewModel()
//            {
//                UserName = username
//            };
//            var controller = new AdminController(
//                                     userManagerMock.Object,
//                                     dbContextMock.Object,
//                                     adminServiceMock.Object,
//                                     courseCrudServiceMock.Object);
//            //Act & Assert
//            controller
//                .WithCallTo(x => x.EditUser(userViewModel))
//                .Should("_EditUser")
//                .WithModel<UserViewModel>(u =>
//                {
//                    Assert.AreEqual(u.UserName, user.UserName);
//                }
//                );
//        }

//    }
//}
