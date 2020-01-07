using MoshMVC.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoshMVC.ViewModel;

namespace MoshMVC.Controllers
{
    public partial class MoviesController : Controller
    {
        private EFDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new EFDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _dbContext.Movies.Include(m => m.Genre);
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

        public ActionResult New()
        {
            var viewModel = new MoviesFormViewModel()
            {
                Movie = new Movie(),
                Genres = _dbContext.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new MoviesFormViewModel()
            {
                Movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id),
                Genres = _dbContext.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel
                {
                    Movie = movie,
                    Genres = _dbContext.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0) // int default value = 0, means is a new action
            {
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateAdded = movie.DateAdded;
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}