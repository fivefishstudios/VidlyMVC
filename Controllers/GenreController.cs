using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class GenreController : Controller
    {
        private readonly MyDBContext _context;

        public GenreController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<Genre> GetAllGenre()
        {
            var genres = _context.Genre.ToList();
            return genres;
        }

        // GET: Genre
        public ActionResult Index()
        {
            // display all records
            var genres = GetAllGenre();
            return View(genres);
        }

        public ActionResult Add()
        {
            // add new record
            // first, we display the Genre add form page

            return View();
        }

        [HttpPost]
        public ActionResult Save(Genre genre)
        {
            // select database, add model, then save
            // then route back to Index
            _context.Genre.Add(genre);
            _context.SaveChanges();

            return RedirectToAction("Index", "Genre");
        }
    }
}