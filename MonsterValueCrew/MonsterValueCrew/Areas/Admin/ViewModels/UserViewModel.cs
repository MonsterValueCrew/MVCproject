using MonsterValueCrew.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MonsterValueCrew.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public bool Checked { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                };
            }
        }
    }
}