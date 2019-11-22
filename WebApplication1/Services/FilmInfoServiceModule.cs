using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Interfaces;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class FilmInfoServiceModule : NinjectModule
    {
        public FilmInfoServiceModule()
        {
        }

        public override void Load()
        {
            
            Bind<DbContext>().To<FilmInfoContext>();
            Bind<IRepository<FilmInfo>>().To<FilmInfoRepository>();
            Bind<IRepository<Genre>>().To<GenreRepository>();
            Bind<IFilmInfoService>().To<FilmInfoService>();
        }
    }
}