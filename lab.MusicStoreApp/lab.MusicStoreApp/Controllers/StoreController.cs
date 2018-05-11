using lab.MusicStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.MusicStoreApp.Controllers
{
    public class StoreController : Controller
    {
        private AppDbContext db = new AppDbContext();
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var genres = db.Genres.ToList();

            return View(genres);
        }
        //
        // GET: /Store/Browse?genre=Disco
        public ActionResult Browse(string genre)
        {
            var genreModel = db.Genres.Include("Albums").Single(g => g.Name == genre);

            return View(genreModel);
        }
        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var album = db.Albums.Find(id);

            album.Genre = db.Genres.Find(album.AlbumId);

            album.Artist = db.Artists.Find(album.Genre.GenreId);

            return View(album);
        }
    }
}