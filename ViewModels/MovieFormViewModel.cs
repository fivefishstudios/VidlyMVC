using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }

        // we'll be passing a list of genres, so this need to be Ienumerable
        public IEnumerable<Genre> Genre { get; set; }
    }
}