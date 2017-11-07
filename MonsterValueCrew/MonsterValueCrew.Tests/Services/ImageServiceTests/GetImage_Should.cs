using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Services;
using System.IO;

namespace MonsterValueCrew.Tests.Services.ImageServiceTests
{
    [TestClass]
    public class GetImage_Should
    {
        [TestMethod]
        public void ThrowWhenFileIsNotFound()
        {
            // Arrange
            var imageService = new ImageService();

            // Act & Assert
            Assert.ThrowsException<FileNotFoundException>(() => imageService.GetImage("invalidPath"));
        }
    }
}
