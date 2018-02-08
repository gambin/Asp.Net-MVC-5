using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;


namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult NewRental(NewRentalDto NewRental)
        {
            if (ModelState.IsValid)
            {
                var customerInDb = _context.Customers.Single(c => c.Id == NewRental.CustomerId);
                var moviesInDb = _context.Movies.Where(m => NewRental.MovieIds.Contains(m.Id)).ToList();
                foreach (var movie in moviesInDb)
                {
                    movie.NumberAvailable--;
                    var rental = new Rental
                    {
                        Customer = customerInDb,
                        Movie = movie,
                        DateRented = DateTime.Now
                    };
                    _context.Rentals.Add(rental);
                }
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
