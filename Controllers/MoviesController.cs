using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {


        private MyDBContext _context;

        public MoviesController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies/Random
        public ActionResult Index()
        {
            var movies = GetAllMovies();
            return View(movies);
        }

        // GET: Movies/DetailView/99
        [Route("Movies/DetailView/{id}")]
        public ActionResult View(int id)
        {
           //  Movie movie = GetAllMovies().SingleOrDefault(x => x.Id == id);
            Movie movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            return View(movie);
        }


        private IEnumerable<Movie> GetAllMovies()
        {
            var _movies = _context.Movies;
            return _movies;
        }

    }
}