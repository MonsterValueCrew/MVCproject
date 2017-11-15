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
using System.Text;
using System.Threading.Tasks;
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
            // var storeMock = new Mock<IUserStore<ApplicationDbContext>>();
            var dbContextMock = new Mock<ApplicationDbContext>();

            var servisesMock = new Mock<CourseCrudService>(dbContextMock.Object);
           
            List<Course> courses = new List<Course>()
            {
            new Course()
               {

                        Name = "kakwotoidae",
                        Description = "azsym",
                        PassScore = 5,
                        IsDeleted = false,
               }

        };
            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);

            var resultViewModel = courses.AsQueryable().Select(MonsterValueCrew.Areas.Admin.ViewModels.CourseViewModel.Create).ToList();

            dbContextMock.SetupGet(m => m.Courses).Returns(coursesSetMock.Object);

            CoursesController controller = new CoursesController(servisesMock.Object, dbContextMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.AllCourses())
                .ShouldRenderDefaultView()
                .WithModel<List<MonsterValueCrew.Areas.Admin.ViewModels.CourseViewModel>>(viewModel =>
                {
                    for (int i = 0; i < viewModel.Count; i++)
                    {
                        Assert.AreEqual(resultViewModel[i].Id, viewModel[i].Id);
                    }
                });
        }
    }
}
