using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MonsterValueCrew.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.UserCourseAssignments = new HashSet<UserCourseAssignment>();
        }

        [StringLength(50,
            MinimumLength = 3,
            ErrorMessage = "Enter a first name between 3 and 50 symbols")]
        public string FirstName { get; set; }

        [StringLength(50,
            MinimumLength = 3,
            ErrorMessage = "Enter a last name between 3 and 50 symbols")]
        public string LastName { get; set; }


        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<UserCourseAssignment> UserCourseAssignments { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
