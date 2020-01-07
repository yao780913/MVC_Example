using MoshMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoshMVC.ViewModel
{
    public class MoviesFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        public string FormTitle
        {
            get
            {
                return Movie != null && Movie.Id != 0
                    ? "Edit Movie"
                    : "New Movie";
            }
        }
    }
}