using MonsterValueCrew.Data.DataModels;
using MonsterValueCrew.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace MonsterValueCrew.Services.Contracts
{
    public interface IAdminService
    {
        string ReadJsonFile(HttpPostedFileBase json);

        Course DeserializeJsonString(string jsonString);

        Task SaveCourse(Course course);
        //This is for DeassignCourses
        void DeleteCourseStates(List<DeassignViewModel> model);
        //This is for DeassignCourses
        List<UserCourseAssignment> GetAllUserCourseAssignments();
    }

}
