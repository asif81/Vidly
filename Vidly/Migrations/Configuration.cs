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
                new Genre {  Name = "Comedy"},
                new Genre {  Name = "Adventure"},
                new Genre {  Name = "Fantasy"},
                new Genre {  Name = "Horror"},
                new Genre {  Name = "Drama"},
                new Genre {  Name = "Sci-Fi"},
            };
            Genre.ForEach(s => context.Genre.AddOrUpdate(g => g.Name, s));
            context.SaveChanges();

            var MembershipType = new List<MembershipType>
            {
                new MembershipType {  Name = "Daily"},
                new MembershipType {  Name = "Weekly"},
                new MembershipType {  Name = "Monthly"},
                new MembershipType {  Name = "Quarterly"},
                new MembershipType {  Name = "Yearly"}

            };
            MembershipType.ForEach(s => context.MembershipTypes.AddOrUpdate(ms => ms.Name, s));
            context.SaveChanges();

            var Customer = new List<Customer>
            {
                new Customer {  Name = "Asif Iqbal", BirthDate=DateTime.Parse("1981-03-23"),
                    IsSubscribedToNewsLetter = true, MembershipTypeId=2},
                new Customer {  Name = "Atif Iqbal", BirthDate=DateTime.Parse("1985-02-02"),
                    IsSubscribedToNewsLetter = true, MembershipTypeId=3},
                new Customer {  Name = "Ashar Asif", BirthDate=DateTime.Parse("2012-03-15"),
                    IsSubscribedToNewsLetter = true, MembershipTypeId=4},
                new Customer {  Name = "Saad Asif", BirthDate=DateTime.Parse("2015-01-01"),
                    IsSubscribedToNewsLetter = true, MembershipTypeId=5},
                new Customer {  Name = "Abdullah Iqbal", BirthDate=DateTime.Parse("2018-05-26"),
                    IsSubscribedToNewsLetter = true, MembershipTypeId=1}
                
            };
            Customer.ForEach(s => context.Customers.AddOrUpdate(g => g.Name, s));
            context.SaveChanges();

            var Movie = new List<Movie>
            {
                new Movie { Name = "Shrek 2", GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 },

                new Movie {  Name = "Lords of the ring", GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 },

                new Movie {  Name = "Avenger : Infinity Wars",GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 },

                new Movie { Name = "Boss baby", GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 },

                new Movie {  Name = "Forest gump", GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 },

                new Movie {   Name = "Jupitor Ascending", GenreId=1, DateAdded= DateTime.Parse("2019-03-31"),
                    ReleaseDate = DateTime.Parse("2008-05-06"),NoOfCopiesAvailable=10 }
            };
            Movie.ForEach(s => context.Movies.AddOrUpdate(m => m.Name, s));
            context.SaveChanges();
        }
    }
}
