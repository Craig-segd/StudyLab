namespace StudyLab.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddAdmin : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], " +
                "[PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], " +
                "[TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], " +
                "[UserName]) VALUES (N'14304f5f-45b5-41e3-b50d-1fd17f75740a', N'admin@studylab.com', " +
                "0, N'AAYS5GgVI1m4jrDPQrFSL6LUuqb4xToOWq5Bpc3Dy/hYjxSY4g5d1zJmAgulBgDYuQ==', N'c2e208c5-aafc-4318-8b78-8d02bde56d70', " +
                "NULL, 0, 0, NULL, 1, 0, N'admin@studylab.com')"
            );
        }

        public override void Down()
        {
        }
    }
}
