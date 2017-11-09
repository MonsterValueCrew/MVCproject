using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterValueCrew.Data.DataModels
{
    public class UserCourseAssignmentModel
    {
        public StatusName Name { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsAssigned { get; set; }

        public string ApplicationUserId { get; set; }

        public int CourseId { get; set; }

    }
}
