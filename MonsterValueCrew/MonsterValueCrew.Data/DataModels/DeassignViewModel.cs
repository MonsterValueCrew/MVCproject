using MonsterValueCrew.Data.Models;
using System.ComponentModel;

namespace MonsterValueCrew.Data.DataModels
{
    public class DeassignViewModel
    {
        [DisplayName(" ")]
        public bool IsSelected { get; set; }

        public UserCourseAssignment userCourseAssignmentMiddleMan { get; set; }
    }
}
