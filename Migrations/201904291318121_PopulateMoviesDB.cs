namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesDB : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Actor) VALUES ('Long Shot', 'Charlize Theron')");
            Sql("INSERT INTO Movies (Name, Actor) VALUES ('Star Wars', 'Daisy Ridley')");
            Sql("INSERT INTO Movies (Name, Actor) VALUES ('Toy Story 4', 'Christina Hendricks')");
            Sql("INSERT INTO Movies (Name, Actor) VALUES ('Terminator', 'Arnold Schwarzenegger')");
            Sql("INSERT INTO Movies (Name, Actor) VALUES ('Gemini Man', 'Will Smith')");
            Sql("INSERT INTO Movies (Name, Actor) VALUES ('The Prodigy', 'Peter Mooney')");

        }
        
        public override void Down()
        {
        }
    }
}
