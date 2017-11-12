using System;
using System.Collections.Generic;

namespace MonsterValueCrew.Areas.Admin.ViewModels
{
    public class UserCourseAssignmentViewModel
    {
        public List<UserViewModel> Users { get; set; }

        public List<CourseViewModel> Courses { get; set; }
        
        public bool IsMandatory { get; set; }
        
        public DateTime DueDate { get; set; }


    }
}