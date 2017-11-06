﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterValueCrew.Data.Models
{
    public class UserCourseAssignment
    {
        public int Id { get; set; }

        [Required]
        public StatusName Name { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }

        [Required]
        public bool IsMandatory { get; set; }

        [Required]
        public bool IsAssigned { get; set; }


        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

    }
}
