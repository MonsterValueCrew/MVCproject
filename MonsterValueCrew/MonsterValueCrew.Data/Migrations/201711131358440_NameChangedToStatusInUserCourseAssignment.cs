namespace MonsterValueCrew.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameChangedToStatusInUserCourseAssignment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCourseAssignments", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.UserCourseAssignments", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserCourseAssignments", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.UserCourseAssignments", "Status");
        }
    }
}
