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
                new Genre { GenreId = 1,   Name = "Comedy"},
                new Genre { GenreId = 2,   Name = "Adventure"},
                new Genre { GenreId = 3,   Name = "Fantasy"},
                new Genre { GenreId = 4,   Name = "Horror"},
                new Genre { GenreId = 5,   Name = "Drama"},
                new Genre { GenreId = 6,   Name = "Sci-Fi"},
            };
            Genre.ForEach(s => context.Genre.AddOrUpdate(g => g.Name, s));
            context.SaveChanges();

            var Customer = new List<Customer>
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
            Genre.ForEach(s => context.Genre.AddOrUpdate(g => g.Name, s));
            context.SaveChanges();
        }
    }
}
