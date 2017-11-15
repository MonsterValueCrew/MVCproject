using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices;
using MonsterValueCrew.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MonsterValueCrew.Tests.Services.DataServices.CourseCrudServicesTests
{
   [TestClass]
   public class GetAllCourses_Should
    {
        [TestMethod]
        public void ReturnAllCourses_WhenTheyArePresent()
        {
            //Arrange
            
            var dbContextMock = new Mock<ApplicationDbContext>();
            var dateTimeService = new DateTimeService();

            int courseId = 4;
            var course = new Course()
            {
                Id = courseId,
                Description = "description",
                Name = "name",
                DateAdded = dateTimeService.GetCurrentDate(),
                PassScore = 30
            };

            var courseList = new List<Course>()
            {
                course
            };
            var coursesMock = new Mock<DbSet<Course>>().SetupData(courseList);
            dbContextMock.SetupGet(x => x.Courses).Returns(coursesMock.Object);

            //Act

            var courseService = new CourseCrudService(dbContextMock.Object);
            var valueToAssertAgainst = courseList.Single();
            var testedObject = courseService.GetAllCourses().Single();
           
            //Assert
            Assert.AreEqual  (valueToAssertAgainst.DateAdded, testedObject.DateAdded);
            Assert.AreEqual(valueToAssertAgainst.Description,testedObject.Description);
            Assert.AreEqual(valueToAssertAgainst.Name, testedObject.Name);
            Assert.AreEqual(valueToAssertAgainst.PassScore, testedObject.PassScore);
        }

        [TestMethod]
        public void ReturnEmptyListCourse_WhenNoneArePresent()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();

            var courseList = new List<Course>();
            var coursesMock = new Mock<DbSet<Course>>().SetupData(courseList);

            dbContextMock.SetupGet(x => x.Courses).Returns(coursesMock.Object);

            //Act

            var courseService = new CourseCrudService(dbContextMock.Object);

            //Assert

            Assert.AreNotEqual(courseList, courseService.GetAllCourses());
        }
    }
}
