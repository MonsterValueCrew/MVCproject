using Bytes2you.Validation;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.DataModels;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MonsterValueCrew.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseCrudService services;
        private readonly ApplicationDbContext context;

        public CoursesController(ICourseCrudService services, ApplicationDbContext context)
        {
            Guard.WhenArgument(services, "services").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.services = services;
            this.context = context;
        }
        [Authorize]
        public ActionResult AllCourses()
        {
            var viewModel = this.services.GetCoursesByUserName(this.User.Identity.Name)
                .Select(v => new CourseViewModel()
                {
                    Id = v.Id,
                    Name = v.Name,
                    DateAdded = v.DateAdded,
                    Description = v.Description
                }).ToList();


            return this.View(viewModel);
        }
        [Authorize]
        public ActionResult TakeCourse(int courseId)
        {
            var slides = services.GetAllSlidesForCourse(courseId)
                .Select(s => new Data.DataModels.ImageViewModel()
                {
                    ImageUrl = Convert.ToBase64String(s.ImageInBase64)
                });

            ViewBag.courseId = courseId;

            return this.View(slides);
        }

        [Authorize]
        public ActionResult GetQuestions(int courseId)
        {
            var questions =
                services.GetAllCourseQuestions(courseId).
                Select(q => new CourseQuestions()
                {
                    QuestionName = q.QuestionName,
                    A = q.A,
                    B = q.B,
                    C = q.C,
                    D = q.D,
                    //CorrectAnswer = q.CorrectAnswer
                }).ToList();

            Session["currentCourseId"] = courseId;  
            return this.PartialView("_Questions", questions);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult SendAnswers(List<CourseQuestions> questionsEnum)
        {
            if (ModelState.IsValid)
            {

                var questionsAnswers =
                    services.GetAllCourseQuestions((int)Session["currentCourseId"])
                    .Select(q => new CourseQuestions()
                    {
                        QuestionName = q.QuestionName,
                        A = q.A,
                        B = q.B,
                        C = q.C,
                        D = q.D,
                        CorrectAnswer = q.CorrectAnswer
                    }).ToList();

                var passScore = services.GetCoursePassScoreByCourseId((int)Session["currentCourseId"]);
                int pointsPerQuestion = (passScore.PassScore / questionsAnswers.Count);

                ExamResults result = new ExamResults()
                {
                    ScoreToPass = passScore.PassScore
                };

                foreach (var qn in questionsEnum)
                {
                    if (questionsAnswers.
                        Where(x => x.QuestionName == qn.QuestionName).
                        Select(x => x.CorrectAnswer).
                        Contains(qn.SelectedAnswer))
                    {
                        result.Score++;
                    }
                }

                if (result.Score >= result.ScoreToPass)
                {
                    result.Pass = true;
                }

                var currentUser = services.GetUserByUserName(this.User.Identity.Name);

                services.SetAssignmentCompletionStatus((int)Session["currentCourseId"], result.Pass);

                return this.View("Results", result);


            }
            return this.View(questionsEnum);

        }
    }
}