using System;
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

        [Required]
        public string Name { get; set; }

        public string Actor { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Must be between 1 to 20.")]
        [Display(Name = "Number in Stock")]
        public int Stock { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        public string Rating { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}