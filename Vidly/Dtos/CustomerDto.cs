using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name Field is Required")]
        [StringLength(255)]
        public string name { get; set; }
        public string surname { get; set; }
        public bool isSubscribedToNewsLetter { get; set; }
        public byte membershipTypeId { get; set; }
        //[AgeBiggerThan18]
        public DateTime? BirthdayDate { get; set; }
    }
}