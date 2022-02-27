using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "The Name Field is Required")]
        [StringLength(255)]
        public string name { get; set; }
        [Required(ErrorMessage = "The Genre Field is Required")]
        public int genreId { get; set; }
        [Required(ErrorMessage = "The Release Date Field is Required")]
        public DateTime? releaseDate { get; set; }
        [Required(ErrorMessage = "The Number in Stock Field is Required")]
        [Range(1, 20, ErrorMessage = "The Number of Movie in stock should be between 1 and 20")]
        public int? stock { get; set; }
        public List<Genre> GenreList { get; set; }

        public NewMovieViewModel(Movie movie)
        {
            id = movie.id;
            name = movie.name;
            genreId = movie.genreId;
            releaseDate = movie.releaseDate;
            stock = movie.stock;
        }

        public NewMovieViewModel()
        {
            id = 0;
        }
    }
}