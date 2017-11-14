using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonsterValueCrew.Areas.Admin.ViewModels
{
    public class UserCourseAssignmentViewModel
    {
        public List<UserViewModel> Users { get; set; }

        public List<CourseViewModel> Courses { get; set; }

        public string Name { get; set; }

        public StatusName Status { get; set; }

        [Display(Name = "Mandatory")]
        public bool IsMandatory { get; set; }
        
        public DateTime DueDate { get; set; }

        public DateTime AssignmentDate { get; set; }
        
        public DateTime? CompletionDate { get; set; }
    }
}