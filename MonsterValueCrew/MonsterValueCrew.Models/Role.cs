using System.Collections.Generic;

namespace MonsterValueCrew.Models
{
    public class Role
    {
        public Role()
        {
            this.Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }

        public string Name { get; set; }    

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
