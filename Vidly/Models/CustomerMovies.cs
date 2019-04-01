using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class CustomerMovies
    {
        [Key]
        [Column(Order = 1)]
        public int CustomerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int MovieId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }
}