using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface IFilmInfoService
    {
        IEnumerable<Genre> GetAllGenres();
        string GetPicCardPath(int id);
        IEnumerable<FilmInfo> GetAllCards();
        IEnumerable<FilmInfo> GetAllCards(string genreName);
        int GetMaxCardId();
        FilmInfo GetCard(int id);
        void CreateCard(FilmInfo item);
        void UpdateCard(FilmInfo item);
        void DeleteCard(int id);
        IEnumerable<FilmInfo> GetCardsByGenreName(string genreName);
        ComplexInfo GetComplexInfo();
        ComplexInfo GetComplexInfo(string genreName);
        void SetPageInfo(int pageIndex, int itemsPerPage, int itemsAllCount);

    }
}
