namespace MonsterValueCrew.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompletionAndAssignmentDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCourseAssignments", "AssignmentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserCourseAssignments", "CompletionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCourseAssignments", "CompletionDate");
            DropColumn("dbo.UserCourseAssignments", "AssignmentDate");
        }
    }
}
