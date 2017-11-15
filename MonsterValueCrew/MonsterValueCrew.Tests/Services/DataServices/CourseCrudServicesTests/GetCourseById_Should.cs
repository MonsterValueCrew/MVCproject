using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MonsterValueCrew.Tests.Services.DataServices.CourseCrudServicesTests
{
    [TestClass]
    public class GetCourseById_Should
    {
        [TestMethod]
        public void GetCourse_WhenIdIsPresent()
        {
            //Arrange

            var dbContextMock = new Mock<ApplicationDbContext>();

            int courseId = 4;
            DateTime date = DateTime.Now;
            
            var course = new Course()
            {
                Id = courseId,
                Description = "description",
                Name = "name",
                DateAdded = date,
                PassScore = 30
            };
            var courseList = new List<Course>()
            {
                course
            };

            var courseDbSetMock = new Mock<DbSet<Course>>().SetupData(courseList);
            dbContextMock.SetupGet(x => x.Courses).Returns(courseDbSetMock.Object);

            //Act

            var courseService = new CourseCrudService(dbContextMock.Object);

            //Assert

            Assert.AreEqual(courseList.First(), courseService.GetCourseById(courseId));
            Assert.AreEqual(dbContextMock.Object.Courses.Count(), 1);
        }


        [TestMethod]
        public void ReturnEmptyCourse_WhenNoCourseIsFound()
        {
            var dbContextMock = new Mock<ApplicationDbContext>();
            var courseList = new List<Course>() { };
            var courseDbSetMock = new Mock<DbSet<Course>>().SetupData(courseList);

            dbContextMock.SetupGet(x => x.Courses).Returns(courseDbSetMock.Object);

            //Act

            CourseCrudService courseService = new CourseCrudService(dbContextMock.Object);

            //Assert

            Assert.AreEqual(courseList.Count(), 0);

        }
    }
}
