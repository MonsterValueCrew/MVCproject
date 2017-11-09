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
            this.Questions = new HashSet<Question>();
            this.Images = new HashSet<Image>();
            this.DateAdded = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50,
            ErrorMessage = "Enter a course name with maximum 50 symbols.")]
        public string Name { get; set; }
        [Required]
        [StringLength(500,
            ErrorMessage = "Enter a course description with maximum 500 symbols.")]
        public string Description { get; set; }

        [Display(Name = "Date Added")]
        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Pass Score")]
        [Required]
        public int PassScore { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<UserCourseAssignment> UserCourseAssignments { get; set; }



    }
}
