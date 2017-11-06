namespace MonsterValueCrew.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserCourseAssignment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCourseAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        IsMandatory = c.Boolean(nullable: false),
                        IsAssigned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserCourseAssignments");
        }
    }
}
