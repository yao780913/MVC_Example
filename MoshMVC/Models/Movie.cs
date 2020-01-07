using MoshMVC.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoshMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "名稱")]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "類型")]
        public int GenreId { get; set; }

        [Display(Name = "庫存")]
        public byte NumberInStock { get; set; }

        [Display(Name = "發行日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateAddedValidation]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "添加日?")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
    }
}