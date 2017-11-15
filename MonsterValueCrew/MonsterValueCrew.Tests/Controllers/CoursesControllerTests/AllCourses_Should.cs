using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

            var resultViewModel = courses.AsQueryable().Select(CourseViewModel.Create).ToList();

            dbContextMock.SetupGet(m => m.Courses).Returns(coursesSetMock.Object);

            var controller = new CoursesController(servisesMock.Object, dbContextMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.DisplayAllCourses())
                .ShouldRenderDefaultView()
                .WithModel<List<CourseViewModel>>(viewModel =>
                {
                    for (int i = 0; i < viewModel.Count; i++)
                    {
                        Assert.AreEqual(resultViewModel[i].Id, viewModel[i].Id);
                    }
                });
        }
    }
}
