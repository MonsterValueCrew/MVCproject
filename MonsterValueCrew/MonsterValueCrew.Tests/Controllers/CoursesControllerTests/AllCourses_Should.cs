//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MonsterValueCrew.Controllers;
//using MonsterValueCrew.Data;
//using MonsterValueCrew.Data.DataModels;
//using MonsterValueCrew.Data.Models;
//using MonsterValueCrew.DataServices.Interfaces;
//using Moq;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Security.Principal;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Routing;

//namespace MonsterValueCrew.Tests.Controllers.CoursesControllerTests
//{
//    [TestClass]
//    public class AllCourses_Should
//    {
//        [TestMethod]
//        public void Return_CorrectViewResult()
//        {
//            // Arrange

//            var dbContextMock = new Mock<ApplicationDbContext>();

//            var servisesMock = new Mock<ICourseCrudService>(dbContextMock.Object);
//            //var username = "username";

//            var user = new ApplicationUser()
//            {
//                Id = "userid",
//                UserName = "username"
//            };

//            var courses = new List<Course>()
//            {
//                new Course()
//                {
//                    Name = "username",
//                    Description = "azsym",
//                    PassScore = 5,
//                    IsDeleted = false,
//                }

//            };
//            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);
//            var usersList = new List<ApplicationUser>() { user };
//            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(usersList);
//            dbContextMock.SetupGet(x => x.Users).Returns(usersDbSetMock.Object);

//            var resultViewModel = courses.AsQueryable().Select(CourseViewModel.Create).ToList();

//            dbContextMock.SetupGet(m => m.Courses).Returns(coursesSetMock.Object);

//            var httpContext = new Mock<HttpContextBase>();
//            var mockIdentity = new Mock<IIdentity>();
//            httpContext.SetupGet(x => x.User.Identity).Returns(mockIdentity.Object);
//            mockIdentity.Setup(x => x.Name).Returns("usetrname");

//            var controller = new CoursesController(servisesMock.Object, dbContextMock.Object);

//            controller.ControllerContext = new ControllerContext(httpContext.Object,
//                                                                   new RouteData(), controller);

//            // Act & Assert
//            //controller
//            //    .WithCallTo(c => c.AllCourses())
//            //    .ShouldRenderDefaultView()
//            //    .WithModel<List<CourseViewModel>>(v =>
//            //    {
//            //        for (int i = 0; i < v.Count; i++)
//            //        {
//            //            Assert.AreEqual(resultViewModel[i].Name, viewModel[i].Name);
//            //        }
//            //    });
//        }
//    }
//}
