using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.Controllers;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Services.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
   public class DisplayCourses_Should
    {
        [TestMethod]
        public void DisplayCourses_WithCorrectStatus()
        {
            //Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var dbContextMock = new Mock<ApplicationDbContext>();
            var adminServiceMock = new Mock<IAdminService>();
            var courseCrudServiceMock = new Mock<ICourseCrudService>();

            
        }
    }
}
