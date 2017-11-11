using MonsterValueCrew.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MonsterValueCrew.Models
{
    public class TakeACourseViewModel
    {
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

        public IList<Question> Questions { get; set; }

        public IList<Image> Images { get; set; }

        public IList<UserCourseAssignment> UserCourseAssignments { get; set; }


    }
}