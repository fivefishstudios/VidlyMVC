namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreDB : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreName) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Action')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Drama')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Adventure')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Mystery')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Horror')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Documentary')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Animation')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Science Fiction')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Foreign Film')");
        }

        public override void Down()
        {
        }
    }
}
