namespace Vidly.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vidly.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidly.Models.ApplicationDbContext context)
        {
            var Genre = new List<Genre>
            {
                new Genre { GenreId = 1,   Name = "Comedy"},
                new Genre { GenreId = 2,   Name = "Adventure"},
                new Genre { GenreId = 3,   Name = "Fantasy"},
                new Genre { GenreId = 4,   Name = "Horror"},
                new Genre { GenreId = 5,   Name = "Drama"},
                new Genre { GenreId = 6,   Name = "Sci-Fi"},
            };
            Genre.ForEach(s => context.Genre.AddOrUpdate(g => g.Name, s));
            context.SaveChanges();

            var MembershipType = new List<MembershipType>
            {
                new MembershipType { Id = 1,   Name = "Daily"},
                new MembershipType { Id = 2,   Name = "Weekly"},
                new MembershipType { Id = 3,   Name = "Monthly"},
                new MembershipType { Id = 4,   Name = "Quarterly"},
                new MembershipType { Id = 5,   Name = "Yearly"}
                
            };
            MembershipType.ForEach(s => context.MembershipTypes.AddOrUpdate(ms => ms.Name, s));
            context.SaveChanges();

            var Customer = new List<Customer>
            {
                new Customer { CustomerId = 1,   Name = "Asif Iqbal", BirthDate=DateTime.Parse("1981-03-23"),
                    IsSubscribedToNewsLetter = true, MembershipTypeId=2},
                new Customer { CustomerId = 1,   Name = "Atif Iqbal", BirthDate=DateTime.Parse("1985-02-02"),
                    IsSubscribedToNewsLetter = true, MembershipTypeId=3},
                new Customer { CustomerId = 1,   Name = "Ashar Asif", BirthDate=DateTime.Parse("2012-03-15"),
                    IsSubscribedToNewsLetter = true, MembershipTypeId=4},
                new Customer { CustomerId = 1,   Name = "Saad Asif", BirthDate=DateTime.Parse("2015-01-01"),
                    IsSubscribedToNewsLetter = true, MembershipTypeId=5},
                new Customer { CustomerId = 1,   Name = "Abdullah Iqbal", BirthDate=DateTime.Parse("2018-05-26"),
                    IsSubscribedToNewsLetter = true, MembershipTypeId=1}
                
            };
            Customer.ForEach(s => context.Customers.AddOrUpdate(g => g.Name, s));
            context.SaveChanges();

            var Movie = new List<Movie>
            {
                new Movie { MovieId = 1,   Name = "Shrek 2", GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 },

                new Movie { MovieId = 2,   Name = "Lords of the ring", GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 },

                new Movie { MovieId = 3,   Name = "Avenger : Infinity Wars",GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 },

                new Movie { MovieId = 4,   Name = "Boss baby", GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 },

                new Movie { MovieId = 5,   Name = "Forest gump", GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 },

                new Movie { MovieId = 6,   Name = "Jupitor Ascending", GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 }
            };
            Movie.ForEach(s => context.Movies.AddOrUpdate(m => m.Name, s));
            context.SaveChanges();
        }
    }
}
