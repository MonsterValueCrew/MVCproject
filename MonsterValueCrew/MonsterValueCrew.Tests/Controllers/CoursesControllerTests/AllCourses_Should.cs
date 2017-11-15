using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.Controllers;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestStack.FluentMVCTesting;

namespace MonsterValueCrew.Tests.Controllers.CoursesControllerTests
{
    [TestClass]
    public class AllCourses_Should
    {
        

        [TestMethod]
        public void Return_CorrectViewResult()
        {
            // Arrange
            
            var dbContextMock = new Mock<ApplicationDbContext>();

            var servisesMock = new Mock<CourseCrudService>(dbContextMock.Object);
            //var username = "username";

            var user = new ApplicationUser()
            {
                Id = "userid",
                UserName = "username"
            };
            List<Course> courses = new List<Course>()
            {
            new Course()
               {

                        Name = "username",
                        Description = "azsym",
                        PassScore = 5,
                        IsDeleted = false,
               }

        };
            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);
            var usersList = new List<ApplicationUser>() { user };
            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(usersList);
            dbContextMock.SetupGet(x => x.Users).Returns(usersDbSetMock.Object);

            var resultViewModel = courses.AsQueryable().Select(MonsterValueCrew.Areas.Admin.ViewModels.CourseViewModel.Create).ToList();

            dbContextMock.SetupGet(m => m.Courses).Returns(coursesSetMock.Object);

            var httpContext = new Mock<HttpContextBase>();
            var mockIdentity = new Mock<IIdentity>();
            httpContext.SetupGet(x => x.User.Identity).Returns(mockIdentity.Object);
            mockIdentity.Setup(x => x.Name).Returns("usetrname");

            CoursesController controller = new CoursesController(servisesMock.Object, dbContextMock.Object);

            controller.ControllerContext = new ControllerContext(httpContext.Object,
                                                                   new RouteData(), controller);

            // Act & Assert
            controller
                .WithCallTo(c => c.DisplayAllCourses())
                .ShouldRenderDefaultView()
                .WithModel<List<MonsterValueCrew.Areas.Admin.ViewModels.CourseViewModel>>(viewModel =>
                {
                    for (int i = 0; i < viewModel.Count; i++)
                    {
                        Assert.AreEqual(resultViewModel[i].Name, viewModel[i].Name);
                    }
                });
        }
    }
}
