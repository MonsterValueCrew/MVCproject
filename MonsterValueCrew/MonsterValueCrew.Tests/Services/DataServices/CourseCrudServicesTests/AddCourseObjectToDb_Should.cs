using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterValueCrew.Tests.Services.DataServices.CourseServicesTests
{
    [TestClass]
    public class AddCourseObjectToDb_Should
    {
        [TestMethod]
        public async Task AddCourseObjectToDb_WhenParametersAreCorrect()
        {
            //Arrange

            var dbContextMock = new Mock<ApplicationDbContext>();

            var course = new Course()
            {
                Id = 8,
                Name = "course",
                Description = "description",
                PassScore = 10,
                DateAdded = new DateTime(2017, 11, 10)
            };
            var courses = new List<Course>();
            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);

            dbContextMock.SetupGet(c => c.Courses).Returns(coursesSetMock.Object);

            var service = new CourseCrudService(dbContextMock.Object);


            //Act

            await service.AddCourseObjectToDb(course);
            var courseInDb = dbContextMock.Object.Courses.Single();

            //Assert
            Assert.AreEqual(course, courseInDb);
            dbContextMock.Verify(m => m.SaveChangesAsync(), Times.Once);
            //Assert.AreEqual(name, courseInDb.Name);
            //Assert.AreEqual(description, courseInDb.Description);
            //Assert.AreEqual(passedScore, courseInDb.PassScore);
            //Assert.AreEqual(dateTime, courseInDb.DateAdded);


        }
        
    }
}
