namespace StudyLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuestionsAnswers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JavaScripts", "Question", c => c.String());
            AddColumn("dbo.JavaScripts", "Answer", c => c.String());
            AddColumn("dbo.Mvcs", "Question", c => c.String());
            AddColumn("dbo.Mvcs", "Answer", c => c.String());
            AddColumn("dbo.Reacts", "Question", c => c.String());
            AddColumn("dbo.Reacts", "Answer", c => c.String());
            AddColumn("dbo.WebApis", "Question", c => c.String());
            AddColumn("dbo.WebApis", "Answer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WebApis", "Answer");
            DropColumn("dbo.WebApis", "Question");
            DropColumn("dbo.Reacts", "Answer");
            DropColumn("dbo.Reacts", "Question");
            DropColumn("dbo.Mvcs", "Answer");
            DropColumn("dbo.Mvcs", "Question");
            DropColumn("dbo.JavaScripts", "Answer");
            DropColumn("dbo.JavaScripts", "Question");
        }
    }
}
