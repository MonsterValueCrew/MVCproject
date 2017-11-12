using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.DataServices;
using MonsterValueCrew.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterValueCrew.Data;

namespace MonsterValueCrew.Tests.Services.DataServices.CourseServicesTests
{
    [TestClass]
   public class AddCourseObjectToDb_Should
    {
        [TestMethod]
        public async void AddCourseObjectToDbWhenParametersAreCorrect()
        {
            //Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var userManager = new Mock<ApplicationUserManager>();
            Course course = new Course() ;
          

            CourseService service = new CourseService(userManager.Object,dbContextMock.Object);
            //Act
           await service.AddCourseObjectToDb(course);

            //Assert
            var courses = dbContextMock.Object.Courses.Single();
            Assert.AreEqual(course.Name,courses.Name);
        }

    }
}
