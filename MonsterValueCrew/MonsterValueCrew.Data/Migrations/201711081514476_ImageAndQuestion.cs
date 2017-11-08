namespace MonsterValueCrew.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageAndQuestion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ImageInBase64 = c.Binary(nullable: false),
                        Order = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionName = c.String(nullable: false),
                        A = c.String(nullable: false),
                        B = c.String(nullable: false),
                        C = c.String(nullable: false),
                        D = c.String(nullable: false),
                        RightAnswer = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Images", "CourseId", "dbo.Courses");
            DropIndex("dbo.Questions", new[] { "CourseId" });
            DropIndex("dbo.Images", new[] { "CourseId" });
            DropTable("dbo.Questions");
            DropTable("dbo.Images");
        }
    }
}
