using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.DataServices;
using MonsterValueCrew.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterValueCrew.Data;
using MonsterValueCrew.Services;
using System.Data.Entity;

namespace MonsterValueCrew.Tests.Services.DataServices.CourseServicesTests
{
    [TestClass]
    public class AddCourseObjectToDb_Should
    {
        [TestMethod]
        public async  Task AddCourseObjectToDb_WhenParametersAreCorrect()
        {
            //Arrange
            string name = "course";
            string description = "description";
            DateTime dateTime = new DateTime(2017, 11, 10);
            int passedScore = 10;
            int id = 8;

            List<Course> courses = new List<Course>();
          
            Course course = new Course()
            {
                Id=id,
                Name = name,
                Description = description,
                PassScore = passedScore,
                DateAdded = dateTime
            };
            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);

            var dbContextMock = new Mock<ApplicationDbContext>();
            dbContextMock.SetupGet(c => c.Courses).Returns(coursesSetMock.Object);

            CourseCrudService service = new CourseCrudService(dbContextMock.Object);


            //Act

            await service.AddCourseObjectToDb(course);

            //Assert
            var courseInDb = dbContextMock.Object.Courses.Single();
            Assert.AreEqual(course, courseInDb);
            dbContextMock.Verify(m => m.SaveChangesAsync(), Times.Once);
            //Assert.AreEqual(name, courseInDb.Name);
            //Assert.AreEqual(description, courseInDb.Description);
            //Assert.AreEqual(passedScore, courseInDb.PassScore);
            //Assert.AreEqual(dateTime, courseInDb.DateAdded);


        }
        
    }
}
