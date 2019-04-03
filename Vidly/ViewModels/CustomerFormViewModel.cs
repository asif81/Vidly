using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
            CustomerId = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            CustomerId = customer.CustomerId;
            MembershipTypeId = customer.MembershipTypeId;
            Name = customer.Name;
            IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            BirthDate = customer.BirthDate;
        }

        public IEnumerable<MembershipType> MembershipType { get; set; }
        
        public int? CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsLetter { get; set; }
        
        [Required]
        [Display(Name = "Membership Type")]
        public int? MembershipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

        public string Title
        {
            get
            {
                if (CustomerId != null && CustomerId != 0)
                    return "Edit Customer";
                else
                    return "Add New Customer";
            }
        }
    }
}