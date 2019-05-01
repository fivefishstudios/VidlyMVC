namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieDates : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies Set ReleaseDate='1/25/19' , DateAdded='4/20/19'  WHERE Id = 1");
            Sql("Update Movies Set ReleaseDate='2/19/19' , DateAdded='4/20/19'  WHERE Id = 2");
            Sql("Update Movies Set ReleaseDate='3/16/19' , DateAdded='4/20/19'  WHERE Id = 3");
            Sql("Update Movies Set ReleaseDate='4/8/19' , DateAdded='4/20/19'  WHERE Id = 4");
            Sql("Update Movies Set ReleaseDate='11/21/18' , DateAdded='4/20/19'  WHERE Id = 5");
            Sql("Update Movies Set ReleaseDate='12/15/18' , DateAdded='4/20/19'  WHERE Id = 6");

        }
        
        public override void Down()
        {
        }
    }
}
