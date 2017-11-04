using System.Collections.Generic;

namespace MonsterValueCrew.Models
{
    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int EmployeeId { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
