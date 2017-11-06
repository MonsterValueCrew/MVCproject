namespace MonsterValueCrew.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipOfAssignmentWithUserAndCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCourseAssignments", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.UserCourseAssignments", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.UserCourseAssignments", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserCourseAssignments", "CourseId");
            CreateIndex("dbo.UserCourseAssignments", "ApplicationUser_Id");
            AddForeignKey("dbo.UserCourseAssignments", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserCourseAssignments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCourseAssignments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.UserCourseAssignments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserCourseAssignments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserCourseAssignments", new[] { "CourseId" });
            DropColumn("dbo.UserCourseAssignments", "ApplicationUser_Id");
            DropColumn("dbo.UserCourseAssignments", "CourseId");
            DropColumn("dbo.UserCourseAssignments", "ApplicationUserId");
        }
    }
}
