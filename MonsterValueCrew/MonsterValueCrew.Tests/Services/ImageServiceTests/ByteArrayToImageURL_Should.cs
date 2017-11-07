using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Services;
using System;

namespace MonsterValueCrew.Tests.Services.ImageServiceTests
{
    [TestClass]
    public class ByteArrayToImageURL_Should
    {
        [TestMethod]
        public void ReturnCorrectUrl()
        {
            // Arrange
            byte[] content = new byte[] { 1, 2, 3, 67 };
            string base64String = Convert.ToBase64String(content, 0, content.Length);
            string expected = "data:image/jpg;base64," + base64String;
            var helper = new ImageService();

            // Act
            var result = helper.ByteArrayToImageUrl(content);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
