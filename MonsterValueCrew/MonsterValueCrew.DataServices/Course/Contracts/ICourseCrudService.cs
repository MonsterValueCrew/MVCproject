using MonsterValueCrew.Data.DataModels;
using MonsterValueCrew.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterValueCrew.DataServices.Interfaces
{
    public interface ICourseCrudService
    {
        IEnumerable<Course> GetAllCourses();

        IEnumerable<Course> GetCoursesByUserName(string username);

        Course GetCourseById(int courseId);

        string GetCourseName(int courseId);

        ICollection<CourseImageBin> GetAllSlidesForCourse(int courseId);

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

       
    }
}
