﻿using MoshMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoshMVC.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public byte NumberInStock { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
    }
}