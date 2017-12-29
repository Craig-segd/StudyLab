namespace StudyLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoredWholeDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JavaScripts", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Mvcs", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Reacts", "TypeId", "dbo.Types");
            DropForeignKey("dbo.WebApis", "TypeId", "dbo.Types");
            DropIndex("dbo.JavaScripts", new[] { "TypeId" });
            DropIndex("dbo.Mvcs", new[] { "TypeId" });
            DropIndex("dbo.Reacts", new[] { "TypeId" });
            DropIndex("dbo.WebApis", new[] { "TypeId" });
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        AnswerText = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            DropTable("dbo.JavaScripts");
            DropTable("dbo.Mvcs");
            DropTable("dbo.Reacts");
            DropTable("dbo.WebApis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WebApis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mvcs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JavaScripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Questions", "TypeId", "dbo.Types");
            DropIndex("dbo.Questions", new[] { "TypeId" });
            DropTable("dbo.Questions");
            CreateIndex("dbo.WebApis", "TypeId");
            CreateIndex("dbo.Reacts", "TypeId");
            CreateIndex("dbo.Mvcs", "TypeId");
            CreateIndex("dbo.JavaScripts", "TypeId");
            AddForeignKey("dbo.WebApis", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reacts", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Mvcs", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JavaScripts", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
        }
    }
}
