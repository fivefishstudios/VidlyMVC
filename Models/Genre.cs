using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Vidly.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Display(Name = "Movie Genre")]
        public string GenreName { get; set; }
    }
}