using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your full name.")]
        [StringLength(255)]
        [Display(Name = "Enter your full name:")]
        public string Name { get; set; }

        public string City { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Please select Membership type.")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth, mm/dd/yyyy", Prompt = "Enter date of birth")]
        [Min18YearsIfAMember]
        public DateTime Birthdate { get; set; }
    }
}