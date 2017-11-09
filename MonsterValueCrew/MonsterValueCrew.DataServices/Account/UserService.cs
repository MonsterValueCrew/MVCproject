using Bytes2you.Validation;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonsterValueCrew.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public void DeactivateAccount(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var user = this.context.Users.Find(userId);
            Guard.WhenArgument(user, "user").IsNull().Throw();

            user.IsDeleted = true;
            this.context.SaveChanges();
        }

        public void ActivateAccount(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var user = this.context.Users.Find(userId);

            Guard.WhenArgument(user, "user").IsNull().Throw();

            user.IsDeleted = false;
            this.context.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            var users = this.context.Users.ToList();
            return users;
        }

        public ApplicationUser GetById(string id)
        {
            var user = this.context.Users.Find(id);
            return user;
        }

        public void UpdateUserInfo(string id, string username, string email, string firstName, string lastName, string phone, bool isDeleted)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();

            var user = this.context.Users.Find(id);

            Guard.WhenArgument(user, "user").IsNull().Throw();
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();
            Guard.WhenArgument(email, "email").IsNullOrEmpty().Throw();

            user.UserName = username;
            user.Email = email;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phone;
            user.IsDeleted = isDeleted;

            this.context.SaveChanges();
        }

        public void UpdateUserInfoByUser(string id, string firstName, string lastName, string phone)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();

            var user = this.context.Users.Find(id);

            Guard.WhenArgument(user, "user").IsNull().Throw();

            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phone;

            this.context.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetUsersByCourse(string query, int courseId)
        {
            var users = new List<ApplicationUser>();
            if (!string.IsNullOrEmpty(query))
            {
                users = this.context.Users
                     .Where(x => x.UserName.ToLower().Contains(query.ToLower()) ||
                     x.Email.ToLower().Contains(query.ToLower()) ||
                     x.FirstName.ToLower().Contains(query.ToLower()) ||
                     x.LastName.ToLower().Contains(query.ToLower()))
                     .ToList()
                     .OrderByDescending(x => x.RegisteredOn)
                     .ToList();
            }
            else
            {
                users = this.context.Users
                    .ToList()
                    .OrderByDescending(x => x.RegisteredOn)
                    .ToList();
            }

            return users;
        }
    }
}
