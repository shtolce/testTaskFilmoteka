using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Services
{
    public class FilmInfoService : IFilmInfoService
    {
        private IRepository<FilmInfo> _db;
        private IRepository<Genre> _dbGenre;
        #region Часть сервиса, отвечающего за пагинацию
        public PageInfo PageInfo { get; set; }
        public void SetPageInfo(int pageIndex,int itemsPerPage, int itemsAllCount)
        {
            PageInfo = new PageInfo { PageIndex = pageIndex, ItemsPerPage = itemsPerPage, ItemsAllCount = itemsAllCount };
        }
    
        #endregion
        public FilmInfoService(IRepository<FilmInfo> db,IRepository<Genre> dbGenre)
        {
            this._dbGenre = dbGenre;
            this._db = db;
        }
        public ComplexInfo GetComplexInfo()
        {
            return new ComplexInfo()
            {
                Genres = this._dbGenre.GetAll(),
                Cards = _db.GetAll().Skip((PageInfo.PageIndex - 1) * PageInfo.ItemsPerPage).Take(PageInfo.ItemsPerPage),
                PageInfo = this.PageInfo
                
        };
        }
        public ComplexInfo GetComplexInfo(string genreName)
        {
            return new ComplexInfo()
            {
                Genres = this._dbGenre.GetAll(),
                Cards = _db.GetAll().Where(el=>el.Genre.Name==genreName).Skip((PageInfo.PageIndex - 1) * PageInfo.ItemsPerPage)
                        .Take(PageInfo.ItemsPerPage),
                PageInfo = this.PageInfo
            };
        }
        public void CreateCard(FilmInfo item)
        {
            _db.Create(item);
            
        }
        public void DeleteCard(int id)
        {
            _db.Delete(id);
        }
        public IEnumerable<FilmInfo> GetAllCards()
        {
            return _db.GetAll();
        }
        public int GetMaxCardId()
        {
            return _db.GetAll().Max(x=>x.Id)+1;
        }

        public IEnumerable<FilmInfo> GetAllCards(string genreName)
        {
            return _db.GetAll().Where(el => el.Genre.Name == genreName);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _dbGenre.GetAll();
        }
        public IEnumerable<FilmInfo> GetCardsByGenreName(string genreName)
        {
            return _db.GetAll().Where(el=>el.Genre.Name==genreName);
        }
        public FilmInfo GetCard(int id)
        {
            return _db.Get(id);
        }
        public string GetPicCardPath(int id)
        {
            return _db.Get(id).PosterFilePAth;
        }

        public void UpdateCard(FilmInfo item)
        {
            _db.Update(item);
        }
    }
}