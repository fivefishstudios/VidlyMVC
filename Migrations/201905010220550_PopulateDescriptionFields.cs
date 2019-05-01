namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDescriptionFields : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Membershiptypes SET Description='No Discount'  WHERE Id=1");
            Sql("UPDATE Membershiptypes SET Description='Monthly'  WHERE Id=2");
            Sql("UPDATE Membershiptypes SET Description='Quarterly'  WHERE Id=3");
            Sql("UPDATE Membershiptypes SET Description='Annually'  WHERE Id=4");

        }
        
        public override void Down()
        {
        }
    }
}
