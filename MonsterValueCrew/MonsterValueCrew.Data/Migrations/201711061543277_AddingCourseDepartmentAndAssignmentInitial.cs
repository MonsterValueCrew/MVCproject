namespace MonsterValueCrew.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCourseDepartmentAndAssignmentInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.UserCourseAssignments", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCourseAssignments", "CourseId", "dbo.Courses");
            DropIndex("dbo.UserCourseAssignments", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserCourseAssignments", new[] { "CourseId" });
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            DropColumn("dbo.UserCourseAssignments", "ApplicationUserId");
            DropColumn("dbo.UserCourseAssignments", "CourseId");
            DropColumn("dbo.AspNetUsers", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int());
            AddColumn("dbo.UserCourseAssignments", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.UserCourseAssignments", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            CreateIndex("dbo.UserCourseAssignments", "CourseId");
            CreateIndex("dbo.UserCourseAssignments", "ApplicationUserId");
            AddForeignKey("dbo.UserCourseAssignments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserCourseAssignments", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments", "Id");
        }
    }
}
