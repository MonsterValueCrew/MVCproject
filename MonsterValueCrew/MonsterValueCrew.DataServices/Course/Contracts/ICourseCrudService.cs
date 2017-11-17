using MonsterValueCrew.Data.DataModels;
using MonsterValueCrew.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonsterValueCrew.DataServices.Interfaces
{
    public interface ICourseCrudService
    {
        IEnumerable<Course> GetAllCourses();

        IEnumerable<Course> GetCoursesByUserName(string username);

        Course GetCourseById(int courseId);

        //CoursePassScore GetCoursePassScoreByCourseId(int courseId);

        IList<ImageViewModel> GetAllSlidesForCourse(int courseId);

        IList<Image> GetImages(int courseId);

        IList<CourseQuestions> GetAllCourseQuestions(int courseId);

        Task AddCourseObjectToDb(Course course);

        Task AssignCourseToUser(string userName, int courseId,
            bool isAssigned, bool isMandatory, DateTime dueDate);

        Task UnassignCourseFromUser(int courseId, string username);

        ApplicationUser GetUserByUserName(string username);

        CoursePassScore GetCoursePassScoreByCourseId(int courseId);

        Task SetAssignmentCompletionStatus(int courseId, bool completed);

        IEnumerable<UserCourseAssignmentViewModel> GetUsersCourseAssignment(string username);

        IEnumerable<UserCourseAssignmentViewModel> GetUserCourseAssignmentByStatusName(string username, StatusName status);

    }
}
