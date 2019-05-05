using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        // override the IsValid method
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // we need access to Customer class, so use validationContext
            var customer = (Customer)validationContext.ObjectInstance;

            // now we can check whatever customer field we want
            if ((customer.MembershipTypeId == MembershipType.Unknown) || (customer.MembershipTypeId == MembershipType.PayAsYouGo))     // no membership type, so no need for age check
            {
                return ValidationResult.Success;
            }

            // if customer has not entered any birthdate
            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            // compute customers age
            var age = DateTime.Today.Year - customer.Birthdate.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer must be at least 18yrs old.");
        }
    }
}