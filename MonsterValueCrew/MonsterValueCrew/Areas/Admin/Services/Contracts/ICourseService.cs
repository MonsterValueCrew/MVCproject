using MonsterValueCrew.Areas.Admin.ViewModels;
using System.Collections.Generic;
using System.Web;

namespace MonsterValueCrew.Services.Contracts
{
    public interface ICourseService
    {
        void SaveCourse(HttpPostedFileBase json);

        void SaveImagesToCourse(int courseId, List<ImageViewModel> imagesView);
    }

}
