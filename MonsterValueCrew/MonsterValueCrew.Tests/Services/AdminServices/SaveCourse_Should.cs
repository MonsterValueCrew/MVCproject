using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.Services;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MonsterValueCrew.Tests.Services.AdminServices
{
    [TestClass]
    public class SaveCourse_Should
    {
        //[TestMethod]
        //public async Task SaveCourse_WhenJsonFileIsNotNull()
        //{
        //    // Arrange
        //    var dbContextMock = new Mock<ApplicationDbContext>();
        //    var services = new AdminService(dbContextMock.Object);
        //    var courseMock = new Mock<Course>();

        //    string name = "course";
        //    string description = "description";
        //    DateTime dateTime = new DateTime(2017, 11, 10);
        //    int passedScore = 10;
        //    int id = 8;
        //    var course = new Course()
        //    {
        //        Id = id,
        //        Name = name,
        //        Description = description,
        //        PassScore = passedScore,
        //        DateAdded = dateTime
        //    };

        //    var courses = new List<Course>();
        //    var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);
            
        //    dbContextMock.Object.Courses.Add(courseMock.Object);

        //    // Act & Assert
        //    //Assert.AreEqual(dbContextMock.Object.Courses.Count(), 1);
        //    dbContextMock.Verify(c => c.Courses.Add(It.IsAny<Course>()), Times.Once);
        //    dbContextMock.Verify(c => c.SaveChangesAsync(), Times.Once);

        //}

        //[TestMethod]
        //public async Task ThrowArgumentNullException_WhenParameterIsNull()
        //{
        //    //Arrange
        //    var dbContextMock = new Mock<ApplicationDbContext>();
        //    var services = new AdminService(dbContextMock.Object);

        //    //Act & Assert
        //    Assert.ThrowsException<ArgumentNullException>(async () => await services.SaveCourse(null));
        //}


    }

    
}
