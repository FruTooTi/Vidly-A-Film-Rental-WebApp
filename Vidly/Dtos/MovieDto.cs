using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "The Name Field is Required")]
        [StringLength(255)]
        public string name { get; set; }
        [Required(ErrorMessage = "The Genre Field is Required")]
        public int genreId { get; set; }
        [Required(ErrorMessage = "The Release Date Field is Required")]
        public DateTime? releaseDate { get; set; }
        public DateTime? dateAdded { get; set; }
        [Required(ErrorMessage = "The Number in Stock Field is Required")]
        [Range(1, 20, ErrorMessage = "The Number of Movie in stock should be between 1 and 20")]
        public int? stock { get; set; }
    }
}