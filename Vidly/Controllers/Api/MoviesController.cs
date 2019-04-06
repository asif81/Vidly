using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Movies
        private IHttpActionResult GetMovies()
        {
            var movieDto = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDto);
        }

        // GET /api/movies/1
        private IHttpActionResult GetMovie(int Id)
        {
            Movie movie = _context.Movies.SingleOrDefault(c => c.MovieId == Id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.MovieId = movie.MovieId;
            return Created(new Uri(Request.RequestUri + "/" + movie.MovieId), movieDto);
        }

        // PUT /api/Movies/1
        public IHttpActionResult UpdateMovie(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieIndDb = _context.Movies.SingleOrDefault(c => c.MovieId == Id);
            if (movieIndDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieIndDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieIndDb = _context.Movies.SingleOrDefault(c => c.MovieId == Id);
            if (movieIndDb == null)
                return NotFound();

            _context.Movies.Remove(movieIndDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
