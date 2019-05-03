using Vidly.Models;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.Models.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Vidly.Models.MyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Genre.AddOrUpdate(
                g => g.GenreName,
                new Genre()
                {
                    GenreName = "Action"
                },
                new Genre()
                {
                    GenreName = "Drama"
                },
                new Genre()
                {
                    GenreName = "Science Fiction"
                },
                new Genre()
                {
                    GenreName = "Comedy"
                },
                new Genre()
                {
                    GenreName = "Animation"
                },
                new Genre()
                {
                    GenreName = "Science Fiction"
                },
                new Genre()
                {
                    GenreName = "Documentary"
                },
                new Genre()
                {
                    GenreName = "Horror"
                });

            context.MembershipType.AddOrUpdate(
                m => m.Description,
                new MembershipType()
                {
                    Id = 1,
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0,
                    Description = "Pay as you go"
                },
                new MembershipType()
                {
                    Id = 2,
                    SignUpFee = 10,
                    DurationInMonths = 1,
                    DiscountRate = 10,
                    Description = "Monthly"
                },
                new MembershipType()
                {
                    Id = 3,
                    SignUpFee = 20,
                    DurationInMonths = 3,
                    DiscountRate = 20,
                    Description = "Quarterly"
                },
                new MembershipType()
                {
                    Id = 4,
                    SignUpFee = 30,
                    DurationInMonths = 12,
                    DiscountRate = 30,
                    Description = "Annually"
                }
                );

            context.Movies.AddOrUpdate(
                m => m.Name,
                new Movie()
                {
                    Name = "Top Gun",
                    Actor = "Tom Cruise",
                    Stock = 4,
                    ReleaseDate = new DateTime(1980, 3, 22),
                    DateAdded = new DateTime(1984, 6, 4),
                    Rating = "PG",
                    GenreId = 4
                },
                new Movie()
                {
                    Name = "Mrs. Doubtfire",
                    Actor = "Robin Williams",
                    Stock = 4,
                    ReleaseDate = new DateTime(1990, 5, 12),
                    DateAdded = new DateTime(1992, 4, 14),
                    Rating = "PG",
                    GenreId = 5
                },
                new Movie()
                {
                    Name = "Sound of Music",
                    Actor = "Julie Andrews",
                    Stock = 14,
                    ReleaseDate = new DateTime(1960, 9, 13),
                    DateAdded = new DateTime(1990, 3, 26),
                    Rating = "PG",
                    GenreId = 7
                },
                new Movie()
                {
                    Name = "Alien",
                    Actor = "Sigourney Weaver",
                    Stock = 4,
                    ReleaseDate = new DateTime(1984, 11, 5),
                    DateAdded = new DateTime(1986, 9, 29),
                    Rating = "PG",
                    GenreId = 3
                },
                new Movie()
                {
                    Name = "Toy Story",
                    Actor = "Tom Hanks",
                    Stock = 24,
                    ReleaseDate = new DateTime(1995, 5, 12),
                    DateAdded = new DateTime(1999, 12, 24),
                    Rating = "PG",
                    GenreId = 2
                }
            );

            context.SaveChanges();
        }
    }
}