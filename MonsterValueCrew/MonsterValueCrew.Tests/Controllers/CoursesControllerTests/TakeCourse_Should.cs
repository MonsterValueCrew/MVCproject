
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.DataServices.Interfaces;
using Moq;

namespace MonsterValueCrew.Tests.Controllers.CoursesControllerTests
{
    [TestClass]
    public class TakeCourse_Should
    {
        public void ReturnCorrectView_WhenParametersAreCorrect()
        {
            //Arrange

            var dbContextMock = new Mock<ApplicationDbContext>();
            var servisesMock = new Mock<ICourseCrudService>(dbContextMock.Object);

            var controller = new CoursesController(servisesMock.Object, dbContextMock.Object);

            int courseId = 4;
            //Act & Assert
            //controller
            //   .WithCallTo(c => c.TakeCourse(courseId))
            //   .ShouldRenderDefaultView()
            //   .WithModel<List<CourseViewModel>>(v =>
            //   {
            //       for (int i = 0; i < v.Count; i++)
            //       {
            //           Assert.AreEqual(resultViewModel[i].Id, v[i].Id);
            //       }
            //   });
        }

    }
}
