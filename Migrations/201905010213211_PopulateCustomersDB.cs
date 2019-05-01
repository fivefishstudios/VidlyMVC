namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomersDB : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, City, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Ruel Vasquez', 'Brentwood, TN', 0, 1)");
            Sql("INSERT INTO Customers (Name, City, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('John Maverick', 'Franklin, TN', 0, 2)");
            Sql("INSERT INTO Customers (Name, City, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Jose Feliciano', 'Nashville, TN', 0, 4)");
            Sql("INSERT INTO Customers (Name, City, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Josie Pussycat', 'Los Angeles, CA', 0, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
