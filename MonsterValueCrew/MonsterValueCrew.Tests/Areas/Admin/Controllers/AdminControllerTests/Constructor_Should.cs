using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Services.Contracts;
using Moq;
using System;

namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenUserIdentityIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var adminServiceMock = new Mock<IAdminService>();
            var courseCrudServiceMock = new Mock<ICourseCrudService>();

            //Act & Assert

            Assert.ThrowsException<ArgumentNullException>(() => new AdminController(null, dbContextMock.Object, adminServiceMock.Object, courseCrudServiceMock.Object));
        }
        [TestMethod]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            //Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var adminServiceMock = new Mock<IAdminService>();
            var courseCrudServiceMock = new Mock<ICourseCrudService>();

            //Act & Assert

            Assert.ThrowsException<ArgumentNullException>(() => new AdminController(userManagerMock.Object, null, adminServiceMock.Object, courseCrudServiceMock.Object));
        }
        [TestMethod]
        public void ThrowArgumentNullException_WhenAdminServiceIsNull()
        {
            //Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var dbContextMock = new Mock<ApplicationDbContext>();
            var courseCrudServiceMock = new Mock<ICourseCrudService>();

            //Act & Assert

            Assert.ThrowsException<ArgumentNullException>(() => new AdminController(userManagerMock.Object, dbContextMock.Object, null, courseCrudServiceMock.Object));
        }
        [TestMethod]
        public void ThrowArgumentNullException_WhenParameterIsNull()
        {
            //Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var dbContextMock = new Mock<ApplicationDbContext>();
            var adminServiceMock = new Mock<IAdminService>();

            //Act & Assert

            Assert.ThrowsException<ArgumentNullException>(() => new AdminController(userManagerMock.Object, dbContextMock.Object, adminServiceMock.Object, null));
        }
    }
}
