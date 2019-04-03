using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            MovieId = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            MovieId = movie.MovieId;
            GenreId = movie.GenreId;
            Name = movie.Name;
            NoOfCopiesAvailable = movie.NoOfCopiesAvailable;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
        }

        public IEnumerable<Genre> Genre { get; set; }
                
        public int? MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
               
        [Required]
        public int? GenreId { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "No. of copies available")]
        public int? NoOfCopiesAvailable { get; set; }

        public string Title
        {
            get
            {
                if (MovieId != null && MovieId != 0)
                    return "Edit Movie";
                else
                    return "Add New Movie";
            }
        }
    }
}