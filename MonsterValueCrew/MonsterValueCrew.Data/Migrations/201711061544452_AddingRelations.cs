namespace MonsterValueCrew.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCourseAssignments", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.UserCourseAssignments", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int());
            CreateIndex("dbo.UserCourseAssignments", "ApplicationUserId");
            CreateIndex("dbo.UserCourseAssignments", "CourseId");
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.UserCourseAssignments", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserCourseAssignments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCourseAssignments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.UserCourseAssignments", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            DropIndex("dbo.UserCourseAssignments", new[] { "CourseId" });
            DropIndex("dbo.UserCourseAssignments", new[] { "ApplicationUserId" });
            DropColumn("dbo.AspNetUsers", "DepartmentId");
            DropColumn("dbo.UserCourseAssignments", "CourseId");
            DropColumn("dbo.UserCourseAssignments", "ApplicationUserId");
        }
    }
}
