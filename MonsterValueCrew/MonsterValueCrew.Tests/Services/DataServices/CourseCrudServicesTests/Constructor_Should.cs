using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.DataServices;
using Moq;
using System;


namespace MonsterValueCrew.Tests.Services.DataServices.CourseServicesTests
{
    [TestClass]
   public class Constructor_Should
    {
   
        [TestMethod]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CourseCrudService(null));
        }
        
        [TestMethod]
        public void ReturnInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();

            //Act
            var courseCrudService = new CourseCrudService(dbContextMock.Object);

            //Assert
            Assert.IsNotNull(courseCrudService);
        }
    }
}
