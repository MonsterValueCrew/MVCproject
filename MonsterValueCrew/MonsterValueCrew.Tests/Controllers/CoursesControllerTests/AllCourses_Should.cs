using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Services;
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

            var servisesMock = new Mock<ICourseCrudService>(dbContextMock.Object);
            var dateTimeService = new DateTimeService();

            var courses = new List<Course>()
            {
                new Course()
                {
                    Id = 0,
                    Name = "Programming",
                    DateAdded = dateTimeService.GetCurrentDate(),
                    Description = "Best Course Ever"
                },
                new Course()
                {
                    Id = 1,
                    Name = "Programmingsadf",
                    DateAdded = dateTimeService.GetCurrentDate(),
                    Description = "Best Course Everer"
                }

            };
            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);

            var resultViewModel = courses.AsQueryable().Select(CourseViewModel.Create).ToList();

            dbContextMock.SetupGet(m => m.Courses).Returns(coursesSetMock.Object);

            var controller = new CoursesController(servisesMock.Object, dbContextMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.AllCourses())
                .ShouldRenderDefaultView()
                .WithModel<List<CourseViewModel>>(v =>
                {
                    for (int i = 0; i < v.Count; i++)
                    {
                        Assert.AreEqual(resultViewModel[i].Id, v[i].Id);
                    }
                });
        }
    }
}
