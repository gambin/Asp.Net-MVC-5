using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Get: All Movies
        [Route("movies")]
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Gender).ToList();
            return View(movies);
        }

        // Get: Movie
        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        // NEW: Movie
        [Route("movies/new")]
        public ActionResult New()
        {
            var genders = _context.Genders.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genders = genders,
                // Movie = new Movie()
            };
            return View("MovieForm", viewModel);
        }

        // Edit: Movie
        [Route("movies/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.First(m => m.Id == id);
            var genders = _context.Genders.ToList();
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genders = genders
                };
                return View("MovieForm", viewModel);
            }
        }

        // Get: Movie by released date
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // Get Movies Methods (Sample)
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Wall-e"}
            };
        }

        // SAVE: Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("movies/save")]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genders = _context.Genders.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var customerInDb = _context.Movies.Single(c => c.Id == movie.Id);
                customerInDb.Name = movie.Name;
                customerInDb.GenderId = movie.GenderId;
                customerInDb.NumberInStock = movie.NumberInStock;
                customerInDb.ReleaseDate = movie.ReleaseDate;
                customerInDb.DateAdded = movie.DateAdded;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


    }
}