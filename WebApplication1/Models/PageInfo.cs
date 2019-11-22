using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public struct PageInfo
    {
        public int PageIndex { get; set; }
        public int ItemsPerPage { get; set; }
        public int ItemsAllCount { get; set; }
        public int PaginLinksPerPage
        {
            get { return (int)Math.Ceiling((float)ItemsAllCount / ItemsPerPage); }
        }
    }

}