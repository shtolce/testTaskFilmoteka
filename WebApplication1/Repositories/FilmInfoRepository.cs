using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class FilmInfoRepository : IRepository<FilmInfo>
    {
        private FilmInfoContext _db;

        public FilmInfoRepository(FilmInfoContext db)
        {
            this._db = db;

        }

        public void Create(FilmInfo item)
        {
            _db.Genres.Attach(item.Genre);
            _db.FilmInfoCatalog.Add(item);
           _db.SaveChanges();
        }

        public void Delete(int id)
        {
            FilmInfo filmSerachedEl  = _db.FilmInfoCatalog.Find(id);
            if (filmSerachedEl != null)
            _db.FilmInfoCatalog.Remove(filmSerachedEl);
            _db.SaveChanges();

        }

        public FilmInfo Get(int id)
        {
            return _db.FilmInfoCatalog.Find(id);
        }

        public IEnumerable<FilmInfo> GetAll()
        {
            return _db.FilmInfoCatalog.Include(el=>el.Genre);
        }

        public void Update(FilmInfo item)
        {
            using (var db = new FilmInfoContext())
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
    }
}