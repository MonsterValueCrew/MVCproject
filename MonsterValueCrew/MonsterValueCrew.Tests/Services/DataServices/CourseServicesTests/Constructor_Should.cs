using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.DataServices;
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
        [TestMethod]
        public void ThrowArgumentNullException_WhenUserManagerIsNull()
        {
            //Arrange
            var userManager = new Mock<ApplicationUserManager>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CourseService(userManager.Object, null));
        }



        [TestMethod]
        public void ThrowArgumentNullException_WhenDbcontextIsNull()
        {
            //Arrange
            var dbContext = new Mock<ApplicationDbContext>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CourseService(null,dbContext.Object));
        }

    }
}
