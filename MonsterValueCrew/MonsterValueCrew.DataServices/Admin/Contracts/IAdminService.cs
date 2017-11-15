using MonsterValueCrew.Data.Models;
using System.Threading.Tasks;
using System.Web;

namespace MonsterValueCrew.Services.Contracts
{
    public interface IAdminService
    {
        string ReadJsonFile(HttpPostedFileBase json);

        Course DeserializeJsonString(string jsonString);

        Task SaveCourse(Course course);
    }

}
