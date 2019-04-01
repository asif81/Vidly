using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
               
        public int GenreId { get; set; }

        [Display(Name = "Released Date")]
        public DateTime ReleaseDate  { get; set; }

        [Display(Name = "Date added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "No. of copies available")]
        public int NoOfCopiesAvailable { get; set; }
    }
}