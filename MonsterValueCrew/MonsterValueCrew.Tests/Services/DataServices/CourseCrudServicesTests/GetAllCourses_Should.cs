using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterValueCrew.Tests.Services.DataServices.CourseCrudServicesTests
{
    [TestClass]
   public class GetAllCourses_Should
    {
        [TestMethod]
        public async Task ReturnAllCourses_WhenTheyArePresent()
        {
            //Arrange
           // string username = "username";
            int courseId = 4;
           // bool isAssigned = true;
            //bool IsMandatory = true;
            DateTime date = DateTime.Now;
            var dbContextMock = new Mock<ApplicationDbContext>();
            List<Course> courseList = new List<Course>();
            
               var course = new Course()
           {
               Id = courseId,
               Description = "description",
               Name = "name",
               DateAdded = date,
               PassScore = 30
           };
            var coursesMock = new Mock<DbSet<Course>>().SetupData(courseList);
            dbContextMock.SetupGet(x => x.Courses).Returns(coursesMock.Object);
            //Act
            CourseCrudService courseService = new CourseCrudService(dbContextMock.Object);
            var valueToAssertAgainst = courseList.Single();
            var testedObject = courseService.GetAllCourses().Single();
            //Assert
           Assert.AreEqual(valueToAssertAgainst.DateAdded, testedObject.DateAdded);
            Assert.AreEqual(valueToAssertAgainst.Description,testedObject.Description);
            Assert.AreEqual(valueToAssertAgainst.Name, testedObject.Name);
            Assert.AreEqual(valueToAssertAgainst.PassScore, testedObject.PassScore);
        }

    }
}
