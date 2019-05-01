namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieStockColumn : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies Set Stock=14  WHERE Id = 1");
            Sql("Update Movies Set Stock=22  WHERE Id = 2");
            Sql("Update Movies Set Stock=16  WHERE Id = 3");
            Sql("Update Movies Set Stock=8  WHERE Id = 4");
            Sql("Update Movies Set Stock=10  WHERE Id = 5");
            Sql("Update Movies Set Stock=4  WHERE Id = 6");
        }
        
        public override void Down()
        {
        }
    }
}
