using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ComplexInfo
    {
        public IEnumerable<FilmInfo> Cards { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}