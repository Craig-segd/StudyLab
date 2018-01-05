namespace StudyLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageText", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "SubjectText", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "SubjectText", c => c.String());
            AlterColumn("dbo.Messages", "MessageText", c => c.String());
        }
    }
}
