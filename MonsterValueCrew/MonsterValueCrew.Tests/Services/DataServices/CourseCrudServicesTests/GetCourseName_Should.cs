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
    public class GetCourseName_Should
    {
        [TestMethod]
        public void GetCourseName_WhenNameIsPresent()
        {
            //Arrange

            int courseId = 4;
            var name = "somename";
            DateTime date = DateTime.Now;
            var dbContextMock = new Mock<ApplicationDbContext>();


            var course = new Course()
            {
                Id = courseId,
                Description = "description",
                Name = name,
                DateAdded = date,
                PassScore = 30
            };
            var courseList = new List<Course>()
            {
                course
            };
            var coursesMock = new Mock<DbSet<Course>>().SetupData(courseList);
            dbContextMock.SetupGet(x => x.Courses).Returns(coursesMock.Object);
            var courseService = new CourseCrudService(dbContextMock.Object);

            //Act
            
            var valueToAssertAgainst = courseList.Single();
            var testedObject = courseService.GetAllCourses().Single();

            //Assert

            Assert.AreEqual(valueToAssertAgainst.Name, testedObject.Name);

        }
    }
}
