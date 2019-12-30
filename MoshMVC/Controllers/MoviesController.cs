using MoshMVC.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoshMVC.Controllers
{
    public class MoviesController : Controller
    {
        private EFDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new EFDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _dbContext.Movies.Include( m => m.Genre);
            return View(movies);
        }

        public ActionResult Detail(int id)
        {
            var movie = _dbContext.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}