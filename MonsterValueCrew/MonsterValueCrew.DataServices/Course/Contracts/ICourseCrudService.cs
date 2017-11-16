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

        string GetCourseName(int courseId);

        IList<ImageViewModel> GetAllSlidesForCourse(int courseId);

        IList<Image> GetImages(int courseId);

        IEnumerable<CourseQuestions> GetAllCourseQuestions(int courseId);

        Task AddCourseObjectToDb(Course course);

        //Do we need to add CourseId here or not?
        Task AddCourseToDb(string name, string description,
            int passScore, bool isDeleted);

        Task AssignCourseToUser(string userName, int courseId,
            bool isAssigned, bool isMandatory, DateTime dueDate);

        Task AssignCourseToDepartment(int departmentID, int courseId,
            bool isAssigned, bool isMandatory, DateTime dueDate);

        Task UnassignCourseFromUser(int courseId, string username);

        ApplicationUser GetUserByUserName(string username);

        CoursePassScore GetCoursePassScoreByCourseId(int courseId);

        Task SetAssignmentCompletionStatus(int courseId, bool completed);

        void SetAssignmentStartedStatus(int courseId, string userId);

        IEnumerable<UserCourseAssignmentViewModel> GetUsersCourseAssignment(string username);

        IEnumerable<UserCourseAssignmentViewModel> GetUserCourseAssignmentByStatusName(string username, StatusName status);

    }
}
