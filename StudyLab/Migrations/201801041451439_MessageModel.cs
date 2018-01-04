namespace StudyLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        SubjectText = c.String(),
                        DateTimeSent = c.DateTime(),
                        RecieverId = c.String(maxLength: 128),
                        SenderId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RecieverId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.RecieverId)
                .Index(t => t.SenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "RecieverId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.Messages", new[] { "RecieverId" });
            DropTable("dbo.Messages");
        }
    }
}
