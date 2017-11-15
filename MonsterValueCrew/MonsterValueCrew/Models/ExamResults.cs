using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterValueCrew.Models
{
    public class ExamResults
    {
        public bool Pass { get; set; }
        public int Score { get; set; }
        public int ScoreToPass { get; set; }
    }
}