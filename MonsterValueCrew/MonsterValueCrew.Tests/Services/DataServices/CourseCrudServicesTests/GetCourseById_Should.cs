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
    public class GetCourseById_Should
    {
        [TestMethod]
        public void GetCourse_WhenIdIsPresent()
        {
            //Arrange
            // string username = "username";
            int courseId = 4;
            // bool isAssigned = true;
            //bool IsMandatory = true;
            DateTime date = DateTime.Now;
            var dbContextMock = new Mock<ApplicationDbContext>();


            var course = new Course()
            {
                Id = courseId,
                Description = "description",
                Name = "name",
                DateAdded = date,
                PassScore = 30
            };
            List<Course> courseList = new List<Course>() { course };
            var courseDbSetMock = new Mock<DbSet<Course>>().SetupData(courseList);
            dbContextMock.SetupGet<IDbSet<Course>>(x => x.Courses).Returns(courseDbSetMock.Object);
            //Act
            CourseCrudService courseService = new CourseCrudService(dbContextMock.Object);
            //Assert
            Assert.AreEqual(courseList.First(), courseService.GetCourseById(courseId));
        }

        // TODO not working properly
        [TestMethod]
        public void ReturnEmptyCourse_WhenNoCourseIsFound()
        {
           
            int courseId = 4;
            var dbContextMock = new Mock<ApplicationDbContext>();
            List<Course> courseList = new List<Course>() {  };
            var courseDbSetMock = new Mock<DbSet<Course>>().SetupData(courseList);
            dbContextMock.SetupGet<IDbSet<Course>>(x => x.Courses).Returns(courseDbSetMock.Object);
            //Act
            CourseCrudService courseService = new CourseCrudService(dbContextMock.Object);
            //Assert
            Assert.AreNotEqual(courseList.First(), courseService.GetCourseById(courseId));

        }
    }
}
