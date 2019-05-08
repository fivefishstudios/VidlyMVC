using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class GenresController : ApiController
    {
        private readonly MyDBContext _context;

        public GenresController()
        {
            _context = new MyDBContext();
        }

        // GET /api/genres
        // get all genre records
        public IEnumerable<Genre> GetGenres()
        {
            var genres = _context.Genre.ToList();
            return genres;
        }

        // GET /api/genres/1
        // get genre with specific id#
        public Genre GetGenre(int id)
        {
            var genre = _context.Genre.SingleOrDefault(g => g.Id == id);
            if (genre != null)
            {
                // record found
                return genre;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE /api/genres/1
        // delete genre with specific id#
        [HttpDelete]
        public void DeleteGenre(int id)
        {
            var genre = _context.Genre.SingleOrDefault(g => g.Id == id);
            if (genre != null)
            {
                // record id found, now delete this
                _ = _context.Genre.Remove(genre);  // this just removes from memory
                _ = _context.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // POST /api/genre/
        // add a new genre record
        [HttpPost]
        public Genre CreateGenre(Genre genre)
        {
            // validate model
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            // if good, save
            _ = _context.Genre.Add(genre);
            _ = _context.SaveChanges();

            // return model
            return genre;
        }

        // PUT /api/genres/1
        // update specific genre record
        [HttpPut]
        public Genre UpdateGenre(int id, Genre genre)
        {
            // validate model
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            // check if record exists
            var genreInDb = _context.Genre.SingleOrDefault(g => g.Id == id);
            if (genreInDb != null)
            {
                // record id found, now update this
                genreInDb.GenreName = genre.GenreName;
                _ = _context.SaveChanges();
                return genreInDb;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}