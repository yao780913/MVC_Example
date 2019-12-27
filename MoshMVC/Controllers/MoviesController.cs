using MoshMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoshMVC.Controllers
{
    public class MoviesController : Controller
    {
        readonly IEnumerable<Movie> movies;

        public MoviesController()
        {
            movies = new List<Movie>() 
            {
                new Movie{ Id = 1, Name = "Mission Impossible"},
                new Movie{ Id = 2, Name = "Mission Impossible 2"},
            };
        }
        // GET: Movies
        public ActionResult Index()
        {
            return View(movies);
        }
    }
}