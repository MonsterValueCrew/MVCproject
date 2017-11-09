using MonsterValueCrew.Areas.Admin.ViewModels;
using MonsterValueCrew.Data.Models;
using System.Collections.Generic;
using System.Web;

namespace MonsterValueCrew.Services.Contracts
{
    public interface ICourseService
    {
        Course GetCourseById(int id);

        void SaveCourse(HttpPostedFileBase json);

        byte[] ImageToByteArray(HttpPostedFileBase image);

        void SaveSlidesToCourse(int courseId, List<ImageViewModel> imagesView);
    }

}
