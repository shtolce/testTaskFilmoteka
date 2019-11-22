using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Models
{
    public class FilmInfo
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Превышено допустимое количество символов")]
        public string Name { get; set; }
        public string PosterFilePAth { get; set; }
        public string Info { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public Genre Genre { get; set; }
        [Range(1700, 3000, ErrorMessage = "Недопустимый год")]
        public int Year { get; set; }
        public int GenreId { get; set; }

    }
}