using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Driving License")]
        public string drivingLicense { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}