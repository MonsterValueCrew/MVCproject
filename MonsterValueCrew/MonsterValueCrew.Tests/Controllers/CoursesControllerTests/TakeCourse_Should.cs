
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.DataModels;
using MonsterValueCrew.DataServices.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace MonsterValueCrew.Tests.Controllers.CoursesControllerTests
{
    [TestClass]
    public class TakeCourse_Should
    {
        [TestMethod]
        public void ReturnCorrectView_WhenParametersAreCorrect()
        {
            //Arrange

            var dbContextMock = new Mock<ApplicationDbContext>();
            var servicesMock = new Mock<ICourseCrudService>();

            var courseId = 1;
            var urlInBase64 = "dXJs";
            byte[] encoded = Convert.FromBase64String("dXJs");
            
            var imageViewModelList = new List<ImageViewModel>()
            {
                new ImageViewModel()
                {
                    ImageUrl = urlInBase64,
                    ImageInBase64 = encoded
                }
            };

            servicesMock.Setup(s => s.GetAllSlidesForCourse(courseId)).Returns(imageViewModelList);

            var controller = new CoursesController(servicesMock.Object, dbContextMock.Object);

            //Act & Assert

            controller
               .WithCallTo(c => c.TakeCourse(courseId))
               .ShouldRenderDefaultView()
               .WithModel<List<ImageViewModel>>(v =>
               {
                   for (int i = 0; i < v.Count; i++)
                   {
                       Assert.AreEqual(imageViewModelList[i].ImageUrl, v[i].ImageUrl);
                   }
               });
        }

    }
}
