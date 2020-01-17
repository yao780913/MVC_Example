using MoshMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MoshMVC.Dtos;

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
            var movies = _dbContext.Movies
                .Include(m => m.Genre)
                .Select(Mapper.Map<Movie, MovieDto>)
                .ToList();

            if (movies == null)
                return NotFound();

            return Ok(movies);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var movie = _dbContext.Movies
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult Post(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            return Created(new Uri($"{Request.RequestUri}/{movie.Id}"), movieDto);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return BadRequest();

            Mapper.Map(movieDto, movieInDb);

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            _dbContext.Movies.Remove(movieInDb);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
