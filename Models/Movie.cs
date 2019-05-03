﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Number in Stock")]
        public int Stock { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        public string Rating { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }
    }
}