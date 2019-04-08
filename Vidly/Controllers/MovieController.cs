using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movie
        public ActionResult Index()
        {
            if (!User.IsInRole(RoleNames.CanManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.MovieId == Id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new ViewModels.MovieFormViewModel()
            {                
                Genre = genre
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var genre = _context.Genre.ToList();
                var viewModel = new ViewModels.MovieFormViewModel(movie)
                {
                    Genre = genre
                };
                return View("MovieForm", viewModel);
            }
             
            if (movie.MovieId == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.MovieId == movie.MovieId);

                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.Name = movie.Name;
                MovieInDb.NoOfCopiesAvailable = movie.NoOfCopiesAvailable;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.DateAdded = movie.DateAdded;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.MovieId == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new ViewModels.MovieFormViewModel(movie)
            {                
                Genre = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}