using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _moviesList;
        public MoviesController()
        {
            _moviesList = new ApplicationDbContext();
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { name = "Shrek"};
            var customer = new List<Customers>
            {
                new Customers{name = "Kerem"},
                new Customers{name = "Gorkem"}
            };
            var viewModel = new randomViewModel()
            {
                movies = movie,
                customers = customer
            };
            return View(viewModel);
            //return Content("Hello World");
            //return RedirectToAction("Index", "Home", new { id = 1, name = "home" });
            //return new EmptyResult();
            //return HttpNotFound();
        }

        //public ActionResult Index(int movieId)
        //{
        //    return Content("id= " + movieId);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrEmpty(sortBy))
        //        sortBy = "Name";
        //    return Content(string.Format("pageindex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        //[Route("Movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult moviesByDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        [Route("Movies/Details/{id}")]
        public ActionResult Detail(int? id)
        {
            var movie = _moviesList.Movies.SingleOrDefault(m => m.id == id);
            return View(movie);
        }

        public ActionResult Index()
        {
            var Movies = _moviesList.Movies.ToList();
            return View(Movies);
        }
    }
}