using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Services;
using System;

namespace MonsterValueCrew.Tests.Services.DateTimeServiceTests
{
    [TestClass]
    public class GetCurrentDate_Should
    {
        [TestMethod]
        public void ReturnCurrentDateTime()
        {
            // Arrange
            var dateTimeService = new DateTimeService();

            // Act
            var result = dateTimeService.GetCurrentDate();

            // Assert
            Assert.AreEqual(result.Day, DateTime.UtcNow.Day);
            Assert.AreEqual(result.Month, DateTime.UtcNow.Month);
            Assert.AreEqual(result.Year, DateTime.UtcNow.Year);
            Assert.IsInstanceOfType(result, typeof(DateTime));
        }
    }
}
