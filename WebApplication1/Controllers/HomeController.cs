
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Controllers
{

    public class HomeController : Controller
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private const int ItemsPerPage = 3;
        private IFilmInfoService _db;
        public HomeController(IFilmInfoService db)
        {
            this._db = db;
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        [HttpGet]
        public ActionResult Index(string genreName = null,int pageIndex = 1)
        {
            ViewBag.activeUser = UserManager.FindById(User.Identity.GetUserId());

            if (Request.Cookies.Get("selectedItemSideMenu") != null)
            {
                Response.Cookies.Add(new HttpCookie("selectedItemSideMenu", "All"));
            }

            #region Пагинация

            if (genreName == null || genreName == "All")
            {
                _db.SetPageInfo(pageIndex, ItemsPerPage, _db.GetAllCards().Count());
            }
            else
            {
                _db.SetPageInfo(pageIndex, ItemsPerPage, _db.GetAllCards(genreName).Count());
            }

            #endregion
            if (genreName == null || genreName == "All")
            {
                Response.Cookies.Set(new HttpCookie("selectedItemSideMenu", "All"));
                return View(_db.GetComplexInfo());
            }
            else
            {
                Response.Cookies.Set(new HttpCookie("selectedItemSideMenu", genreName));
                return View(_db.GetComplexInfo(genreName));
            }



        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.Message = "Введите информацию о фильме";
            ViewBag.Title = "Создание карточки фильма.";
            SelectList items = new SelectList(_db.GetAllGenres(), "Id", "Name");
            ViewBag.Genres = items;
            FilmInfo newFilmInfoCard = new FilmInfo();
            newFilmInfoCard.Id = _db.GetMaxCardId();
            return View(newFilmInfoCard);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(FilmInfo film)
        {
            Genre genre = _db.GetAllGenres().FirstOrDefault(x => x.Id == film.GenreId);
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            if (genre != null)
            {
                
                film.User = user.UserName;
                film.Email = user.Email;
                film.Genre = genre;
                film.PosterFilePAth = "/posterPicStore/" + film.PosterFilePAth;
                if (film.PosterFilePAth == "/posterPicStore/")
                    film.PosterFilePAth = "/posterPicStore/default.jpg";

                if (ModelState.IsValid)
                    if (user.Email != "")
                    {
                        _db.CreateCard(film);
                        return RedirectToAction("Index");

                    }
            }
            ViewBag.Message = "Введите информацию о фильме";
            ViewBag.Title = "Создание карточки фильма.";
            SelectList items = new SelectList(_db.GetAllGenres(), "Id", "Name");
            ViewBag.Genres = items;
            FilmInfo newFilmInfoCard = new FilmInfo();
            newFilmInfoCard.Id = _db.GetMaxCardId();
            return View(newFilmInfoCard);

        }
        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            if (user.Email == _db.GetCard(id).Email)
            {
                _db.DeleteCard(id);
            }


            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Введите информацию о фильме";
            ViewBag.Title = "Редактироание карточки фильма.";
            SelectList items = new SelectList(_db.GetAllGenres(), "Id", "Name");
            ViewBag.Genres = items;
            FilmInfo tempCard = _db.GetCard(id);
            return View(tempCard);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(FilmInfo film)
        {
            Genre genre = _db.GetAllGenres().FirstOrDefault(x => x.Id == film.GenreId);
            if (genre != null)
            {
                ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());

                film.User = user.UserName;
                film.Email = user.Email;
                film.Genre = genre;
                string tempPath = HostingEnvironment.MapPath("~/posterPicStore/")+ film.PosterFilePAth;
                FileInfo tempFileInfo = new FileInfo(tempPath);
                bool pathExistFlag = tempFileInfo.Exists;
                if (!(pathExistFlag))
                {
                    string prevPath = _db.GetPicCardPath(film.Id);
                    bool fileInfo = false;
                    if (prevPath!=null)
                        fileInfo = (new FileInfo(HostingEnvironment.MapPath("~/posterPicStore/") + Path.GetFileName(prevPath))).Exists;
                    if (fileInfo==true)
                        film.PosterFilePAth = prevPath;
                    else
                        film.PosterFilePAth = "/posterPicStore/default.jpg";

                }
                else
                {
                    film.PosterFilePAth = "/posterPicStore/" + film.PosterFilePAth;

                }
                if (ModelState.IsValid)
                {
                    _db.UpdateCard(film);
                    return RedirectToAction("Index");

                }
            }

            ViewBag.Message = "Введите информацию о фильме";
            ViewBag.Title = "Редактироание карточки фильма.";
            SelectList items = new SelectList(_db.GetAllGenres(), "Id", "Name");
            ViewBag.Genres = items;
            return View(_db.GetCard(film.Id));


        }

        [HttpPost]
        public JsonResult Upload(int Id)
        {
            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (upload != null)
                {
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    string ext = System.IO.Path.GetExtension(upload.FileName);
                    upload.SaveAs(Server.MapPath("/posterPicStore/" + Id.ToString()+ ext));
                }
            }
            return Json("файл загружен");
        }



    }
}