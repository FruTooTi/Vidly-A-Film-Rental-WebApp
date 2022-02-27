using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Dtos;

namespace Vidly.Models
{
    public class AgeBiggerThan18 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;
            if (customer.membershipTypeId == MembershipType.Unknown || customer.membershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.BirthdayDate == null)
                return new ValidationResult("The Birthday Date Field is Required");
            if(customer.membershipTypeId != 1)
            {
                var age = DateTime.Now.Year - customer.BirthdayDate.Value.Year;
                if (age < 18)
                    return new ValidationResult("The Customer should be above the age of 18 for Subscription");
            }
            return ValidationResult.Success;
            
        }
    }
}