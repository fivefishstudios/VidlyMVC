using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MyDBContext _context;

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
            var movies = GetAllMovies().Include(m => m.Genre);
            return View(movies);
        }

        // GET: Movies/DetailView/99
        [Route("Movies/DetailView/{id}")]
        public ActionResult View(int id)
        {
            Movie movie = GetAllMovies().Include(m => m.Genre).SingleOrDefault(x => x.Id == id);
            return View(movie);
        }

        private IQueryable<Movie> GetAllMovies()
        {
            var movies = _context.Movies;
            return movies;
        }

        // GET: Display New movie form
        public ActionResult New()
        {
            // display add new movie form
            var newMovie = new MovieFormViewModel()
            {
                Genre = _context.Genre.ToList()
            };

            return View("MovieForm", newMovie);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            // throw new System.NotImplementedException();

            // if movie record is new, add to database
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                // update movie record with new information
                // but first, we need to pull up existing movie record so we're on the right record location,
                // and we can update the fields
                var movieToUpdate = _context.Movies.Single(m => m.Id == movie.Id);
                movieToUpdate.Name = movie.Name;
                movieToUpdate.Actor = movie.Actor;
                movieToUpdate.ReleaseDate = movie.ReleaseDate;
                movieToUpdate.DateAdded = movie.DateAdded;
                movieToUpdate.Stock = movie.Stock;
                movieToUpdate.GenreId = movie.GenreId;
            }
            // save information to database
            _context.SaveChanges();

            // route user back to /Movies url
            return RedirectToAction("Index");
        }
    }
}