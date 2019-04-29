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
        private List<Movie> _movies;
        public MoviesController()
        {
            _movies = new List<Movie>()
            {
                new Movie() { Name = "Mission Impossible", Id=1, Actor = "Tom Cruise" },
                new Movie() { Name = "Top Gun", Id=2, Actor = "Tom Cruise"},
                new Movie() { Name = "Ghost Protocol", Id=3, Actor = "John Doe"},
                new Movie() { Name = "Shrek", Id=4, Actor = "Shrek as himself"},
                new Movie() { Name = "James Bond", Id=5, Actor = "Roger Moore"}
            };
        }

        // GET: Movies/Random
        public ActionResult Index()
        {
            return View(_movies);
        }

        // GET: Movies/DetailView/99
        [Route("Movies/DetailView/{id}")]
        public ActionResult View(int id)
        {
            Movie movie = _movies.Find(x => x.Id == id);
            return View(movie);
        }

    }
}