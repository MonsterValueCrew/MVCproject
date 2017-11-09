using MonsterValueCrew.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MonsterValueCrew.Models
{
    public class UserCourseAssignment
    {
        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public bool IsMandatory { get; set; }

        public bool IsAssigned { get; set; }

        public int EmployeeId { get; set; }


        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public StatusName Name { get; set; }

    }
}
