namespace StudyLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedServerVal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "QuestionText", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "AnswerText", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "AnswerText", c => c.String());
            AlterColumn("dbo.Questions", "QuestionText", c => c.String());
        }
    }
}
