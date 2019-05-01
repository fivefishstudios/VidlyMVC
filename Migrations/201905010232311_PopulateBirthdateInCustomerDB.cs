namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthdateInCustomerDB : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate='2/13/68'  WHERE Id=4");
            Sql("UPDATE Customers SET Birthdate='9/23/64'  WHERE Id=5");
            Sql("UPDATE Customers SET Birthdate='6/4/72'  WHERE Id=6");
            Sql("UPDATE Customers SET Birthdate='12/16/88'  WHERE Id=7");
        }
        
        public override void Down()
        {
        }
    }
}
