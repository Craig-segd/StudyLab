namespace StudyLab.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TestQuestions : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Questions] ON
INSERT INTO[dbo].[Questions]([Id], [QuestionText], [AnswerText], [TypeId]) VALUES(1, N'What is JavaScript?', N'A programming language', 1)
                INSERT INTO[dbo].[Questions]([Id], [QuestionText], [AnswerText], [TypeId]) VALUES(2, N'What is ReactJS?', N'A JavaScript library.', 3)
                INSERT INTO[dbo].[Questions]([Id], [QuestionText], [AnswerText], [TypeId]) VALUES(3, N'What is WebAPI', N'A cross-platform framework. ', 4)
                INSERT INTO[dbo].[Questions] ([Id], [QuestionText], [AnswerText], [TypeId]) VALUES(4, N'What is MVC?', N'An architectural design pattern.', 2)
SET IDENTITY_INSERT [dbo].[Questions] OFF");
        }

        public override void Down()
        {
        }
    }
}
