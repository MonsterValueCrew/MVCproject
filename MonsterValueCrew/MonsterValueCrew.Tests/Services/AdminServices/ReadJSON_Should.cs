using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.Services;
using Moq;
using System;
using System.IO;
using System.Text;
using System.Web;

namespace MonsterValueCrew.Tests.Services.AdminServices
{
    [TestClass]
    public class ReadJSON_Should
    {
        [TestMethod]
        public void ThrowException_WhenJsonIsEmpty()
        {
            //Arrange
            var dbMock = new Mock<ApplicationDbContext>();
            var services = new AdminService(dbMock.Object);
            var jsonFileMock = new Mock<HttpPostedFileBase>();
            var model = new UploadJSONViewModel();
            
            FileStream jsonFileStream = new FileStream(@"..\..\TestApp_Data\EmptyJson.json", FileMode.Open);
            jsonFileMock.Setup(x => x.InputStream).Returns(jsonFileStream);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => services.ReadJsonFile(jsonFileMock.Object));

            jsonFileStream.Dispose();
        }

        [TestMethod]
        public void ThrowException_WhenJsonIsNull()
        {
            //Arrange
            var dbMock = new Mock<ApplicationDbContext>();
            var services = new AdminService(dbMock.Object);
            var jsonFileMock = new Mock<HttpPostedFileBase>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => services.ReadJsonFile(null));

        }
        [TestMethod]
        public void ReturnCourse_WhenParametersAreCorrect()
        {
            //Arrange
            var dbMock = new Mock<ApplicationDbContext>();
            var services = new AdminService(dbMock.Object);
            var jsonFileMock = new Mock<HttpPostedFileBase>();
            var expected = string.Empty;

            FileStream stream = new FileStream(@"..\..\TestApp_Data\FirstCourse.json", FileMode.Open);
            jsonFileMock.Setup(j => j.InputStream).Returns(stream);
            using (BinaryReader biteReader = new BinaryReader(jsonFileMock.Object.InputStream))
            {
                byte[] biteArray = biteReader.ReadBytes(jsonFileMock.Object.ContentLength);

                expected = Encoding.UTF8.GetString(biteArray);
            }
            
            //Act 
            var actual = services.ReadJsonFile(jsonFileMock.Object);

            //Assert
            Assert.AreEqual(expected, actual);

            stream.Dispose();
        }
    }
}
