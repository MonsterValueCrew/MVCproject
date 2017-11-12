using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.DataServices;
using MonsterValueCrew.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonsterValueCrew.Tests.Services.DataServices.CourseServicesTests
{
    [TestClass]
   public class Constructor_Should
    {
   //     [TestMethod]
   //     public void ThrowArgumentNullException_WhenUserManagerIsNull()
   //     {
   //         //Arrange
   //         var userManager = new Mock<ApplicationUserManager>();

   //         // Act & Assert
   //         Assert.ThrowsException<ArgumentNullException>(() => new MonsterValueCrew.Services.CourseService(userManager.Object, null));
   //     }



        [TestMethod]
        public void ThrowArgumentNullException_WhenNullDataIsPassed()
        {
            //Arrange
            //var dbContext = new Mock<ApplicationDbContext>();

            //Arrange Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CourseCrudService(null));
        }

        [TestMethod]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullDataIsPassed()
        {
            // Arrange
            var expectedExMessage = "course";

            // Act and Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
                new CourseCrudService(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        //[TestMethod]
        //public void ShouldNotThrow_WhenValidDependenciesArePassed()
        //{
        //    // Arrange
        //    var mockedData = new Mock<ApplicationDbContext>();

        //    // Act and Assert
        //    Assert.Fail(() =>
        //        new CourseCrudService(mockedData.Object));
        //}
    }
}
