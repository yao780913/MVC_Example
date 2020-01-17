using MoshMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoshMVC.Dtos
{
    public class MovieDto
    {
        [Required]
        public string Name { get; set; }

        public int GenreId { get; set; }

        public byte NumberInStock { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
    }
}