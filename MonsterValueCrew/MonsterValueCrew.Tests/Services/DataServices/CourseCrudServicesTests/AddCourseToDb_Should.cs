using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterValueCrew.Tests.Services.DataServices.CourseServicesTests
{
    [TestClass]
    public class AddCourseToDb_Should
    {
        [TestMethod]
        public async Task AddCourseToDb_WhenParametersAreCorect()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var courses = new List<Course>();
            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);
            
            dbContextMock.SetupGet(c => c.Courses).Returns(coursesSetMock.Object);

            var service = new CourseCrudService(dbContextMock.Object);
            
            string name = "name";
            string description = "description";
            int passcore = 6;
            bool isDeleted = false;

            //Act
            await service.AddCourseToDb(name, description, passcore, isDeleted);
            var result = dbContextMock.Object.Courses.Single();

            //Arrange
            Assert.AreEqual(name, result.Name);
            Assert.AreEqual(description, result.Description);
            Assert.AreEqual(passcore, result.PassScore);
            Assert.AreEqual(isDeleted, result.IsDeleted);
            dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);

        }

        [TestMethod]
        public async Task AddCourseToDb_WhenCourseIsCorrect()
        {
            //Arrange

            var dbContextMock = new Mock<ApplicationDbContext>();
            var courses = new List<Course>();
            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);
           
            var course = new Course()
            {
                Name = "kakwotoidae",
                Description = "azsym",
                PassScore = 5,
                IsDeleted = false,
            };
            
            dbContextMock.SetupGet(c => c.Courses).Returns(coursesSetMock.Object);

            var service = new CourseCrudService(dbContextMock.Object);

            //Act
            await service.AddCourseToDb(course);
            var result = dbContextMock.Object.Courses.Single();

            //Arrange

            Assert.AreEqual(course, result);
            dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);

        }
    }
}
