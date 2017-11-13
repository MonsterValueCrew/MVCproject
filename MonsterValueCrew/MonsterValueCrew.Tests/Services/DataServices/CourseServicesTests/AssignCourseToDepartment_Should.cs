using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterValueCrew.Data;
using MonsterValueCrew.Data.Models;
using MonsterValueCrew.DataServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterValueCrew.Tests.Services.DataServices.CourseServicesTests
{
    [TestClass]
    public class AssignCourseToDepartment_Should
    {
        //     [TestMethod]
        //     public async Task AssignCourseToDepartment_WhenParametersAreCorrect()
        //     {
        //         //Arrange
        //         int departmentId = 4;
        //         int courseId = 2;
        //         bool isAssigned=true;
        //         bool isMandatory=true;
        //         DateTime dateTime = new DateTime(2016,12,12) ;

        //         List<Course> courses = new List<Course>();
        //         Course course = new Course()
        //         {

        //             Name = "kakwotoidae",
        //             Description = "azsym",
        //             PassScore = 5,
        //             IsDeleted = false,
        //         };
        //         List<ApplicationUser> usersList = new List<ApplicationUser>()
        //      {
        //          new ApplicationUser()
        //              {
        //                  FirstName = "fname",
        //                  LastName = "lastname",
        //                  DepartmentId = 1,

        //              },
        //          new ApplicationUser()
        //              {
        //                   FirstName = "assaasa",
        //                  LastName = "lastnassasaame",
        //                  DepartmentId = 1,
        //              },
        //          new ApplicationUser()
        //              {
        //                   FirstName = "ddsdsdsds",
        //                  LastName = "dsdwds",
        //                  DepartmentId = 1,
        //              }
        //      };
        //         var coursesSetMock = new Mock<DbSet<Course>>().SetupData(courses);
        //         var dbContextMock = new Mock<ApplicationDbContext>();
        //         dbContextMock.SetupGet(c => c.Courses).Returns(coursesSetMock.Object);
        //         List<ApplicationUser> userList = new List<ApplicationUser>() {  };
        //         var depDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(usersList);
        //         dbContextMock.SetupGet(c => c.Users).Returns(depDbSetMock.Object);
        //         CourseCrudService service = new CourseCrudService(dbContextMock.Object);
        //         //Act
        //         await service.AssignCourseToDepartment(departmentId,courseId,isAssigned,isMandatory,dateTime);
        //        // var result = dbContextMock.Object.Departments.Single();

        //         //Assert
        //         Assert.AreEqual(3, dbContextMock.Object.Users.Count<ApplicationUser>());
        //         dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        //     }


        [TestMethod]
        public async Task AddCourseToDepartment_WhenParametersAreCorrect()
        {
            //Arrange
            int departmentId = 1;
            int courseId = 1;
            bool isAssigned = true;
            bool isMandatory = true;
            DateTime dateTime = new DateTime();
            var dbContextMock = new Mock<ApplicationDbContext>();
            List<UserCourseAssignment> usersCoursesList = new List<UserCourseAssignment>() { };
            var usersCoursesDbSetMock = new Mock<DbSet<UserCourseAssignment>>().SetupData(usersCoursesList);
            dbContextMock.SetupGet<IDbSet<UserCourseAssignment>>(x => x.UserCourseAssignments).Returns(usersCoursesDbSetMock.Object);

            List<ApplicationUser> usersList = new List<ApplicationUser>()
        {
            new ApplicationUser()
                {
                    FirstName = "uniqueGuidOne",
                    LastName = "first",
                    DepartmentId = 1,
                    
                },
            new ApplicationUser()
                {
                    FirstName = "uniqueGuidTwo",
                    LastName = "second",
                    DepartmentId = 1,
                   
                },
            new ApplicationUser()
                {
                    FirstName = "uniqueGuidThree",
                    LastName = "third",
                    DepartmentId = 1,
                   
                }
        };
            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(usersList);
            dbContextMock.SetupGet<IDbSet<ApplicationUser>>(x => x.Users).Returns(usersDbSetMock.Object);

            CourseCrudService courseService = new CourseCrudService(dbContextMock.Object);
            //Act
            await courseService.AssignCourseToDepartment(departmentId, courseId, isAssigned, isMandatory, dateTime);
            //Assert
            Assert.AreEqual(3, dbContextMock.Object.Users.Count<ApplicationUser>());
            dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

    }
}

