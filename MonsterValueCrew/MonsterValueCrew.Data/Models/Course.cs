using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonsterValueCrew.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.UserCourseAssignments = new HashSet<UserCourseAssignment>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50,
            ErrorMessage = "Enter a course name with maximum 50 symbols.")]
        public string Description { get; set; }

        [Display(Name = "Date Added")]
        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Pass Score")]
        [Required]
        public int PassScore { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<UserCourseAssignment> UserCourseAssignments { get; set; }



    }
}
