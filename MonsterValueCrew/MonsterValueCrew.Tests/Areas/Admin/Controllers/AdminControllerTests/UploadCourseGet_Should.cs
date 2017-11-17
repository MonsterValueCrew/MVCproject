//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MonsterValueCrew.Areas.Admin.Controllers;
//using MonsterValueCrew.Data.DataModels;
//using Moq;

//namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
//{
//    [TestClass]
//    public class UploadCourseGet_Should
//    {
//        [TestMethod]
//        public void ReturnDefaultViewWithCorrectModel()
//        {
//            // Arange
//            var uploadServiceMock = new Mock<IUploadCourseService>();

//            var controller = new AdminController(uploadServiceMock.Object);

//            var expectedModel = new UploadJSONViewModel();
//            // Act && Assert

//            controller
//                .WithCallTo(c => c.UploadCourse())
//                .ShouldRenderDefaultView()
//                .WithModel<UploadJsonModel>(m => Assert.AreEqual(expectedModel.Json, m.Json));
//        }
//    }
//}
