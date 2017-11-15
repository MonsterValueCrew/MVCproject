using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Services;
using System;

namespace MonsterValueCrew.Tests.Services.AdminServices
{
    [TestClass]
    public class Contructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenParameterIsNull()
        {
            //Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AdminService(null));
        }
    }
}