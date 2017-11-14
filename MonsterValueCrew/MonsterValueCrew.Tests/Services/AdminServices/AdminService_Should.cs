using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MonsterValueCrew.Tests.Services.AdminServices
{
    [TestClass]
    public class AdminService_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenParameterIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var services = new AdminService(dbContextMock.Object);
            
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => services.SaveCourse(null));
        }
       

        [TestMethod]
        public void SaveCourse_WhenJsonFileIsNotNull()
        {
            //// Arrange
            //var dbContextMock = new Mock<ApplicationDbContext>();
            //var services = new AdminService(dbContextMock.Object);
            //var courseMock = new Mock<Course>();

            //dbContextMock.Object.Courses.Add(courseMock.Object);
            //// Act
            
            //// Assert
            //Assert.AreEqual(dbContextMock.Object.Courses.Count(), 1);
            //dbContextMock.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
    
}
