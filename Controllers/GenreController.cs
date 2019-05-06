using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
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

        // GET: display ADD form
        public ActionResult Add()
        {
            // add new record
            // first, we display the Genre add form page

            return View("GenreForm", null);
        }

        // POST: Save record for ADD or UPDATE form
        [HttpPost]
        public ActionResult Save(Genre genre)
        {
            // validate genre model
            //if (!ModelState.IsValid)  // this does not work because id is 0 for new ADD
            if (genre.GenreName.IsNullOrWhiteSpace())   // so let's check that GenreName isn't empty
            {
                return View("GenreForm", genre);
            }

            // save action can be used by either ADD or UPDATE operation. we need to detect which one we're doing.
            if (genre.Id == 0)
            {
                // this is an ADD operation
                // select database, add model
                _ = _context.Genre.Add(genre);
            }
            else
            {
                // this is an UPDATE operation
                // first, we need to pull existing record
                var genreToUpdate = _context.Genre.Single(g => g.Id == genre.Id);
                // then update fields
                genreToUpdate.GenreName = genre.GenreName;
            }

            // save model changes to database
            _context.SaveChanges();

            // then route back to Index
            return RedirectToAction("Index", "Genre");
        }

        // GET: Display update form
        public ActionResult Update(byte id)
        {
            // populate model with correct record based on id
            var genreRecord = _context.Genre.Single(g => g.Id == id);
            if (genreRecord == null)
            {
                // no record found
                return HttpNotFound();
            }

            // display this Genre record in a form
            return View("GenreForm", genreRecord);
        }

        // GET: Display DELETE form
        public ActionResult Delete(byte id)
        {
            // retrieve this record and display to user for Delete confirmation
            // populate model with correct record based on id
            // NOTE: ABEND when url passed value is more > 255 because this is declared a byte
            var genreRecord = new Genre();

            try
            {
                genreRecord = _context.Genre.Single(g => g.Id == id);
            }
            catch (Exception e)
            {
                Response.Write(e.Message);  // error message:Sequence contains no elements
                return RedirectToAction("Index");  // back to display all genre page
                //Response.End();
            }

            // display this Genre record in a form
            return View("Delete", genreRecord);
        }

        // POST: Delete record
        [HttpPost]
        public ActionResult Remove(Genre genre)
        {
            var recordToDelete = _context.Genre.Single(g => g.Id == genre.Id);
            _ = _context.Genre.Remove(recordToDelete);
            _ = _context.SaveChanges();

            // back to index page
            return RedirectToAction("Index");
        }
    }
}