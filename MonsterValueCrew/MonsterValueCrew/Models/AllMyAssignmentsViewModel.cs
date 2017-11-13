using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterValueCrew.Models
{
    public class AllMyAssignmentsViewModel
    {
        public int Id { get; set; }

        public StatusName Name { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsMandatory { get; set; }

        public bool IsAssigned { get; set; }

        public int CourseId { get; set; }

    }
}