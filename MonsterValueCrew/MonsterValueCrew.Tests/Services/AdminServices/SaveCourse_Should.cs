using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterValueCrew.Tests.Services.AdminServices
{
    [TestClass]
    public class SaveCourse_Should
    {
        [TestMethod]
        public void SaveCourse_WhenJsonFileIsNotNull()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var services = new AdminService(dbContextMock.Object);

            var byteArray = Convert.FromBase64String("dXJs");
            var question = new Question()
            {
                Id = 0,  
                QuestionName = "name",
                A = "a",
                B = "b",
                C = "c",
                D = "d",
                CorrectAnswer = "d",
                CourseId = 8
            };
            var image = new Image()
            {
                Id = 0,
                CourseId = 8,
                ImageInBase64 = byteArray,
                Name = "name",
                Order = 0
            };
            var course = new Course()
            {
                Id = 8,
                Name = "course",
                Description = "description",
                PassScore = 10,
                DateAdded = new DateTime(2017, 11, 10)
            };

            var coursesList = new List<Course>();
            var questionsList = new List<Question>();
            var imageList = new List<Image>();

            var coursesSetMock = new Mock<DbSet<Course>>().SetupData(coursesList);
            dbContextMock.SetupGet(x => x.Courses).Returns(coursesSetMock.Object);

            var questionSetMock = new Mock<DbSet<Question>>().SetupData(questionsList);
            dbContextMock.SetupGet(x => x.Questions).Returns(questionSetMock.Object);

            var imagesSetMock = new Mock<DbSet<Image>>().SetupData(imageList);
            dbContextMock.SetupGet(x => x.Images).Returns(imagesSetMock.Object);

            dbContextMock.Object.Courses.Add(course);
            dbContextMock.Object.Questions.Add(question);
            dbContextMock.Object.Images.Add(image);

            //dbContextMock.Setup(c => c.SaveChangesAsync()).Verifiable();
            // Act & Assert
            Assert.AreEqual(dbContextMock.Object.Courses.Count(), 1);
            Assert.AreEqual(dbContextMock.Object.Questions.Count(), 1);
            Assert.AreEqual(dbContextMock.Object.Images.Count(), 1);
            //dbContextMock.Verify(c => c.Courses.Add(course), Times.Once);
            //dbContextMock.Verify(c => c.SaveChangesAsync(), Times.Once);

        }
        

    }


}
