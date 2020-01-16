using MoshMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoshMVC.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private EFDbContext _dbContext;
        public MoviesController()
        {
            _dbContext = new EFDbContext();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var movies = _dbContext.Movies.ToList();

            if (movies == null)
                return NotFound();

            return Ok(movies);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var movie = _dbContext.Movies
                .FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public IHttpActionResult Post(Movie movie)
        {

        }
    }
}
