using Microsoft.AspNet.Identity.EntityFramework;
using MonsterValueCrew.Data.Models;
using System.Data.Entity;

namespace MonsterValueCrew.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Department> Departments { get; set; }
        public virtual IDbSet<Course> Courses { get; set; }
        public virtual IDbSet<UserCourseAssignment> UserCourseAssignments { get; set; }
        public virtual IDbSet<Image> Images { get; set; }
        public virtual IDbSet<Question> Questions { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
