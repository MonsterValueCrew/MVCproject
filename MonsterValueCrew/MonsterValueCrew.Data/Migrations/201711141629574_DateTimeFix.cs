namespace MonsterValueCrew.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserCourseAssignments", "CompletionDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserCourseAssignments", "CompletionDate", c => c.DateTime(nullable: false));
        }
    }
}
