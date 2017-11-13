using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonsterValueCrew.Data.Models;

namespace MonsterValueCrew.Models
{
    public class TakeCourseVIewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual ICollection<Image> Images { get; set; }

    }
}