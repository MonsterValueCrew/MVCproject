using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterValueCrew.Data.Models;

namespace MonsterValueCrew.Services.Contracts
{
    public interface ICourseService
    {
        string GetCourseName(int courseId);

        IList<Image> GetImages(int courseId);
    }
}
