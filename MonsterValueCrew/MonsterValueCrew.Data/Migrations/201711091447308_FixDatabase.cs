namespace MonsterValueCrew.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Questions", "CorrectAnswer", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "RegisteredOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Questions", "RightAnswer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "RightAnswer", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "RegisteredOn");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.Questions", "CorrectAnswer");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
