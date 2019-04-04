using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dto
{
    public class CustomerDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsLetter { get; set; }
       
        [Required]
        public int MembershipTypeId { get; set; }
           
        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}