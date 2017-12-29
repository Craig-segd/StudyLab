namespace StudyLab.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Types (Name) VALUES ('JavaScript')");
            Sql("INSERT INTO Types (Name) VALUES ('MVC')");
            Sql("INSERT INTO Types (Name) VALUES ('React')");
            Sql("INSERT INTO Types (Name) VALUES ('WebApi')");
        }

        public override void Down()
        {
        }
    }
}
