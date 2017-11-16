using MonsterValueCrew.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterValueCrew.Data.DataModels
{
    public class UserCourseAssignmentMiddleMan
    {
        public int Id { get; set; }

        public StatusName Status { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime AssignmentDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsAssigned { get; set; }


        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

    }
}
