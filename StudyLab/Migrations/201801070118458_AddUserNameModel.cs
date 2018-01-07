namespace StudyLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNameModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "RecieverUsername", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "RecieverUsername");
        }
    }
}
