using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Areas.Admin.Controllers;
using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.Services.Contracts;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace MonsterValueCrew.Tests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class AllUser_Should
    {
        [TestMethod]
        public void ReturnDefaultViewWithCorrectViewModel()
        {
            //Arrange
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var dbContextMock = new Mock<ApplicationDbContext>();
            var courseServiceMock = new Mock<IAdminService>();

            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser() {UserName = "firstUser" },
                new ApplicationUser() {UserName = "secondUser" }
            };
            var usersSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);

            var resultViewModel = users.AsQueryable().Select(UserViewModel.Create).ToList();

            dbContextMock.SetupGet(u => u.Users).Returns(usersSetMock.Object);

            AdminController controller = new AdminController(userManagerMock.Object, dbContextMock.Object, courseServiceMock.Object);

            //Act & Assert
            controller
                .WithCallTo(c => c.AllUsers())
                .ShouldRenderDefaultView()
                .WithModel<List<UserViewModel>>( v => 
                {
                    for (int i = 0; i < v.Count; i++)
                    {
                        Assert.AreEqual(resultViewModel[i].UserName, v[i].UserName);
                    }
                });

        }
    }
}
