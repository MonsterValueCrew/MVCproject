using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class EditUser_Should
    {
        [TestMethod]
        public async Task ReturnPartialView_WhenParametersAreCorrect()
        {
            //Arrange
            var userMock = new Mock<ApplicationUser>();
            var userManagerMock = new Mock<ApplicationUserManager>(userMock.Object);

            //Act
            //userManagerMock.Setup(u => u.FindByNameAsync(userMock.Object))
            //Assert

        }
        
    }
}
