//using Microsoft.AspNet.Identity;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MonsterValueCrew.Areas.Admin.Controllers;
//using MonsterValueCrew.Data;
//using MonsterValueCrew.Data.DataModels;
//using MonsterValueCrew.Data.Models;
//using MonsterValueCrew.DataServices.Interfaces;
//using MonsterValueCrew.Services;
//using MonsterValueCrew.Services.Contracts;
//using Moq;
//using System.Threading.Tasks;
//using System.Web;
//using TestStack.FluentMVCTesting;

//namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
//{
//    [TestClass]
//    public class UploadCoursePost_Should
//    {
//        [TestMethod]
//        public void ReturnDefaultViewWithCorrectModel()
//        {
//            // Arange
//            var storeMock = new Mock<IUserStore<ApplicationUser>>();
//            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
//            var dbContextMock = new Mock<ApplicationDbContext>();
//            var adminServiceMock = new Mock<IAdminService>();
//            var courseCrudServiceMock = new Mock<ICourseCrudService>();

//            var controller = new AdminController(
//                                    userManagerMock.Object,
//                                    dbContextMock.Object,
//                                    adminServiceMock.Object,
//                                    courseCrudServiceMock.Object);

//            var jsonFileMock = new Mock<HttpPostedFileBase>();
//            var returnString = "returned";
//            var adminService = new Mock<AdminService>();
//            var courseMock = new Mock<Course>();

//            adminService.Setup(a => a.ReadJsonFile(jsonFileMock.Object)).Returns(returnString);
//            adminService.Setup(a => a.DeserializeJsonString(returnString)).Returns(courseMock.Object);
//            adminService.Setup(a => a.SaveCourse(courseMock.Object)).Returns(Task.FromResult(courseMock.Object));

//            var uploadJsonViewModel = new UploadJSONViewModel();
//            //Act && Assert

//            controller
//                .WithCallTo(c => c.UploadCourses(uploadJsonViewModel))
//                .ShouldRenderDefaultView();
//        }
//    }
//}
