using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/Movies
        public IHttpActionResult GetMovie()
        {
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            if (movies == null)
                return BadRequest();
            return Ok(movies);
        }

        public IHttpActionResult GetMovie(int? id)
        {
            var movies = _context.Movies.ToList().SingleOrDefault(m => m.id == id);
            if (movies == null)
                return NotFound();
            return Ok(Mapper.Map<MovieDto>(movies));
        }
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var newMovie = Mapper.Map<MovieDto, Movie>(movie);
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            movie.id = newMovie.id;
            return Created(new Uri(Request.RequestUri + "/" + newMovie.id), movie);
        }
        [HttpPut]
        public IHttpActionResult UpdateMovie(int? id, MovieDto movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var target = _context.Movies.SingleOrDefault(m => m.id == id);
            if (target == null)
                return NotFound();
            Mapper.Map<MovieDto, Movie>(movie, target);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.id == id);
            if (movie == null)
                return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
