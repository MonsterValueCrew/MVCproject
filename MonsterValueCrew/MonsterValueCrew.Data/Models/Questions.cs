using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterValueCrew.Data.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string QuestionName { get; set; }
        [Required]
        public string A { get; set; }
        [Required]
        public string B { get; set; }
        [Required]
        public string C { get; set; }
        [Required]
        public string D { get; set; }
        [Required]  
        public string RightAnswer { get; set; }
        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
