using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Vidly.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {
            // Disable initializer
            // Database.SetInitializer<MyDBContext>(null);

            // Initialization Strategy
            // Database.SetInitializer<MyDBContext>(new CreateDatabaseIfNotExists<MyDBContext>());
            Database.SetInitializer<MyDBContext>(new DropCreateDatabaseIfModelChanges<MyDBContext>());
            // Database.SetInitializer<MyDBContext>(new DropCreateDatabaseAlways<MyDBContext>());
            // Database.SetInitializer<MyDBContext>(new MyDBContextInitializer());
        }

        public DbSet<Customer> Customers { get; set; } // My domain models
        public DbSet<Movie> Movies { get; set; }// My domain models
        public DbSet<MembershipType> MembershipType { get; set; }

        public DbSet<Genre> Genre { get; set; }
    }
}