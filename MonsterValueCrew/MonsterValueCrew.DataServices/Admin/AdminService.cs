﻿using Bytes2you.Validation;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.DataModels;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.Services.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MonsterValueCrew.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;

        public AdminService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }
        public string ReadJsonFile(HttpPostedFileBase json)
        {
            Guard.WhenArgument(json, "json").IsNull().Throw();
            string jsonString = string.Empty;

            if (json.InputStream.CanRead)
            {
                using (BinaryReader biteReader = new BinaryReader(json.InputStream))
                {
                    byte[] biteArray = biteReader.ReadBytes(json.ContentLength);

                    Guard.WhenArgument(biteArray, "No Json Data").IsNullOrEmpty().Throw();

                    jsonString = Encoding.UTF8.GetString(biteArray);
                }
            }
            return jsonString;
        }
        public Course DeserializeJsonString(string jsonString)
        {
            Guard.WhenArgument(jsonString, "JSON string is null or empty").IsNullOrEmpty().Throw();
            Course course = JsonConvert.DeserializeObject<Course>(jsonString);

            return course;
        }
        // Ask BigVik how to make reusable, maybe string,reader, file or something else
        public async Task SaveCourse(Course course)
        {
            Guard.WhenArgument(course, "Course is Null").IsNull().Throw();
            this.context.Courses.Add(course);

            foreach (var question in course.Questions)
            {
                question.CourseId = course.Id;
                this.context.Questions.Add(question);
            }
            foreach (var image in course.Images)
            {
                image.CourseId = course.Id;
                this.context.Images.Add(image);
            }
            await this.context.SaveChangesAsync();
        }

        //This is for DeassignCourses
        public void DeleteCourseStates(List<DeassignViewModel> model)
        {
            for (int i = 0; i < model.Count; i++)
            {
                if (model[i].IsSelected)
                {
                    var currId = model[i].userCourseAssignmentMiddleMan.Id;
                    var currState = this.context.UserCourseAssignments.First(x => x.Id == currId);
                    this.context.UserCourseAssignments.Remove(currState);
                }
            }
            this.context.SaveChanges();
        }
        //This is for DeassignCourses
        public List<UserCourseAssignment> GetAllUserCourseAssignments()
        {
            return this.context.UserCourseAssignments.ToList();
        }
    }

}
