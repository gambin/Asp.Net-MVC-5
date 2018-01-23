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
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: All Movies - /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET: Movie - /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie != null)
            {
                return Ok(Mapper.Map<Movie, MovieDto>(movie));
            } else
            {
                return NotFound();
            }
        }

        // POST: Movie - /api/movies
        [HttpPost]
        public IHttpActionResult AddMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var movie = Mapper.Map<MovieDto, Movie>(movieDto);
                _context.Movies.Add(movie);
                _context.SaveChanges();
                movieDto.Id = movie.Id;
                return Created(new Uri(Request.RequestUri + "/" + movie.Id.ToString()), movieDto);
            }
        }

        // PUT: Movie - api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);
                if (movieInDb == null)
                {
                    return NotFound();
                } else
                {
                    var m = Mapper.Map(movieDto, movieInDb);
                    _context.SaveChanges();
                    return Ok();
                }
            }

        }

    }
}
