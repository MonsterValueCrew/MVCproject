﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterValueCrew.Models
{
    public class AllCoursesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        //IsMandatory is not part of the Assignment DataModel -> it's not shown
        //public bool IsMandatory { get; set; }

    }
}