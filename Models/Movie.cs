using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        // properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Actor { get; set; }
        public int Stock { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public string Rating { get; set; }

        public Genre Genre { get; set; }

    }
}