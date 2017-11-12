using System.Collections.Generic;
using System.Web;

namespace MonsterValueCrew.Services.Contracts
{
    public interface IAdminService
    {
        void SaveCourse(HttpPostedFileBase json);
        
    }

}
