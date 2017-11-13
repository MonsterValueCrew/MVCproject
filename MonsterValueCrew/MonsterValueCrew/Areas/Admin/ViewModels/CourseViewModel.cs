using MonsterValueCrew.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MonsterValueCrew.Areas.Admin.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public int PassScore { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsSelected { get; set; }

        public static Expression<Func<Course, CourseViewModel>> Create
        {
            get
            {
                return c => new CourseViewModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    DateAdded = c.DateAdded,
                    PassScore = c.PassScore,
                    IsDeleted = c.IsDeleted
                };
            }
        }
    }
}