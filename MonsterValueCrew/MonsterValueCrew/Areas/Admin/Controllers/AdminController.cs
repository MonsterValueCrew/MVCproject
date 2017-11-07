using MonsterValueCrew.Areas.Admin.Models;
using MonsterValueCrew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonsterValueCrew.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly ApplicationDbContext dbContext;

        public AdminController(ApplicationUserManager userManager, ApplicationDbContext dbContext)
        {
            this.userManager = userManager ?? throw new ArgumentNullException("userManager");
            this.dbContext = dbContext ?? throw new ArgumentNullException("userManager");
        }

        public ActionResult AllUsers()
        {
            var userViewModel = this.dbContext.Users.Select(UserViewModel.Create).ToList();

            return this.View(userViewModel);
        }
    }
}