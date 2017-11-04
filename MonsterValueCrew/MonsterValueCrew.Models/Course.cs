using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonsterValueCrew.Models
{
    public class Course
    {
        public Course()
        {
            this.UserCourseAssignments = new HashSet<UserCourseAssignment>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public int PassScore { get; set; }
        
        public virtual ICollection<UserCourseAssignment> UserCourseAssignments { get; set; }

        public bool IsDeleted { get; set; }


    }
}
