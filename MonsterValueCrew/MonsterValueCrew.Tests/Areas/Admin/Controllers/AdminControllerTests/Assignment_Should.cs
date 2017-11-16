//using Microsoft.AspNet.Identity;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MonsterValueCrew.Areas.Admin.Controllers;
//using MonsterValueCrew.Data;
//using MonsterValueCrew.Data.DataModels;
//using MonsterValueCrew.Data.Models;
//using MonsterValueCrew.DataServices.Interfaces;
//using MonsterValueCrew.Services.Contracts;
//using Moq;

//namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
//{
//    [TestClass]
//    public class Assignment_Should
//    {
//        [TestMethod]
//        public void ReturnCorrectView_WhenParametersAreCorrect()
//        {
//            //Arrange
//            var storeMock = new Mock<IUserStore<ApplicationUser>>();
//            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
//            var dbContextMock = new Mock<ApplicationDbContext>();
//            var adminServiceMock = new Mock<IAdminService>();
//            var courseCrudServiceMock = new Mock<ICourseCrudService>();
            
//            var resultViewModel = new UserCourseAssignmentViewModel()
//            {
//                Users =
//                {
//                    new UserViewModel() { UserName = "Programming",  Id = "Pesho" },
//                    new UserViewModel() { UserName = "Programming",  Id = "Gosho" }
//                },
//                Courses = {
//                    new CourseViewModel() { Name = "Programming", Id = 0 },
//                    new CourseViewModel() { Name = "Programming", Id = 1 }
//                }
//            };

//            AdminController controller = new AdminController(userManagerMock.Object, dbContextMock.Object, adminServiceMock.Object, courseCrudServiceMock.Object);



//            //Act



//            //Assert
//        }
//    }
//}
