using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Services;
using Moq;
using System;

namespace MonsterValueCrew.Tests.Services.AdminServices
{
    [TestClass]
    public class DeserializeJSON_Should
    {
        [TestMethod]
        public void ThrowExcetion_WhenParametersAreNotCorrect()
        {
            //Arrange
            var dbMock = new Mock<ApplicationDbContext>();
            var services = new AdminService(dbMock.Object);
            
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => services.DeserializeJsonString(null));
        }
    }
}
