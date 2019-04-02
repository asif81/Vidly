using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime ReleaseDate  { get; set; }

        [Required]
        [Display(Name = "Date added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "No. of copies available")]
        public int NoOfCopiesAvailable { get; set; }
    }
}