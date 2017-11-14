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
            var services = new Mock<ICourseCrudService>();
            

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>new CoursesController(services.Object,null));
        }
    }
   
}
