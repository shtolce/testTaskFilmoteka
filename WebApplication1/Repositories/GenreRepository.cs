using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private FilmInfoContext _db;

        public GenreRepository(FilmInfoContext db)
        {
            this._db = db;
        }

        public void Create(Genre item)
        {
            _db.Genres.Add(item);
        }

        public void Delete(int id)
        {
            Genre GenreEl = _db.Genres.Find(id);
            if (GenreEl != null)
            _db.Genres.Remove(GenreEl);
        }

        public Genre Get(int id)
        {
            return _db.Genres.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _db.Genres;
        }

        public void Update(Genre item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}