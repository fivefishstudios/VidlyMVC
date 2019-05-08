using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        // setup context so we can access the database
        private MyDBContext _context;

        public MoviesController()
        {
            _context = new MyDBContext();
        }

        // GET /api/movies
        // get all movies
        public IEnumerable<Movie> GetMovies()
        {
            var movies = _context.Movies.ToList();
            return movies;
        }

        // GET /api/movies/1
        // get movie with specific id
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                // found the movie
                return movie;
            }
        }

        // DELETE /api/movies/1
        // delete movie with specific id
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            // look for this movie id
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                // record found, now delete it
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();
            }
        }

        // POST /api/movie
        // add a new movie to database
        [HttpPost]
        public Movie AddMovie(Movie movie)
        {
            // validate movie
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            // add movie to memory
            _context.Movies.Add(movie);
            _context.SaveChanges();

            // return what we just added
            return movie;
        }

        // PUT /api/movie/1
        // update movie record with new data
        [HttpPut]
        public Movie UpdateMovie(int id, Movie movie)
        {
            // validate movie
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            // find movie record
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            // if not found, return error
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                // if found, update individual fields
                movieInDb.Id = id;
                movieInDb.Name = movie.Name;
                movieInDb.Actor = movie.Actor;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Rating = movie.Rating;
                movieInDb.Stock = movie.Stock;
                movieInDb.GenreId = movie.GenreId;
            }

            // save to database
            _context.SaveChanges();

            // return record
            return movieInDb;
        }
    }
}