using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{   
    public class StoreController : Controller
    {
        private MusicStoreEntities dbContext = new MusicStoreEntities();

        //
        // GET: /Store/
        public ActionResult Index()
        {
            // Temp Code For test
            //SampleData.BuildSampleData();

            //using (var dbContext = new MusicStoreEntities())
            //{                
            var genres = dbContext.Genres.ToList();
            return View(genres);
            //}                            
        }
        //
        // GET: /Store/Browse?genre=Disco
        //public string Browse(string genre)
        public ActionResult Browse(string genre)
        {
            /*
             * Note: We’re using the HttpUtility.HtmlEncode utility method to sanitize the user input. 
             * This prevents users from injecting Javascript into our View with a link 
             * like /Store/Browse?Genre=<script>window.location=’http://hackersite.com’</script>.
             */
            //string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);
            //return message;
            
            if (String.IsNullOrEmpty(genre))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Retrieve Genre and its Associated Albums from database (Query Result Shaping Feature)
            //var genreModel = dbContext.Genres.Include("Albums").Single(g => g.Name == genre);
            var genreModel = dbContext.Genres.Include(g => g.Albums).Single(g => g.Name == genre);
            if (genreModel == null)
            {
                return HttpNotFound();
            }
            return View(genreModel);

        }
        //
        //
        // GET: /Store/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var album = dbContext.Albums.Find(id);
            var album = dbContext.Albums.Include(a => a.Artist).Include(a => a.Genre).Single(a => a.AlbumId == id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = dbContext.Genres.ToList();
            return PartialView(genres);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}