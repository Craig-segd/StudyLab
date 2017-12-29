namespace StudyLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JavaScripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mvcs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Reacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.WebApis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebApis", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Reacts", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Mvcs", "TypeId", "dbo.Types");
            DropForeignKey("dbo.JavaScripts", "TypeId", "dbo.Types");
            DropIndex("dbo.WebApis", new[] { "TypeId" });
            DropIndex("dbo.Reacts", new[] { "TypeId" });
            DropIndex("dbo.Mvcs", new[] { "TypeId" });
            DropIndex("dbo.JavaScripts", new[] { "TypeId" });
            DropTable("dbo.WebApis");
            DropTable("dbo.Reacts");
            DropTable("dbo.Mvcs");
            DropTable("dbo.Types");
            DropTable("dbo.JavaScripts");
        }
    }
}
