using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterValueCrew.Data.Models
{
    public class Department
    {
        public Department()
        {
            this.ApplicationUsers = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50,
            ErrorMessage = "Enter a department name with maximum 50 symbols.")]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
