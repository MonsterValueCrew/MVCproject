using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.DataServices.Interfaces;
using Moq;
using System;
namespace MonsterValueCrew.Tests.Controllers.CoursesControllerTests

{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenServicesisNull()
        {
            //Arrangew
            var context = new Mock<ApplicationDbContext>();


            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CoursesController(null,context.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenContextisNull()
        {
            //Arrangew
            var services = new Mock<ICourseCrudService>();
            

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>new CoursesController(services.Object,null));
        }
        [TestMethod]
        public void ReturnInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var context = new Mock<ApplicationDbContext>();
            var services = new Mock<ICourseCrudService>();

            //Act
            var courseCrudService = new CoursesController(services.Object,context.Object);

            //Assert
            Assert.IsNotNull(courseCrudService);
        }
    }
   
}
