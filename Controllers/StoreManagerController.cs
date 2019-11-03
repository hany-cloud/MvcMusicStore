using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private MusicStoreEntities dbContext = new MusicStoreEntities();

        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = dbContext.Albums.Include(a => a.Artist).Include(a => a.Genre);
            return View(albums.ToList());
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Album album = dbContext.Albums.Find(id);
            Album album = dbContext.Albums.Include(a => a.Artist).Include(a => a.Genre).Single(a => a.AlbumId == id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);            
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(dbContext.Artists, "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(dbContext.Genres, "GenreId", "Name");
            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album) // Model Binding capabilities built into ASP.NET MVC
        //public ActionResult Create(Album album)
        {
            if (ModelState.IsValid) // to validate rules in modeles
            {
                dbContext.Albums.Add(album); // EF to persist the values 
                dbContext.SaveChanges(); // EF generates the appropriate SQL commands to save changes to database
                return RedirectToAction("Index");
            }

            // In case of errors, displaying invalid form submissions with Validation Errors
            ViewBag.ArtistId = new SelectList(dbContext.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(dbContext.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = dbContext.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(dbContext.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(dbContext.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(album).State = EntityState.Modified;
                dbContext.SaveChanges();
                
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(dbContext.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(dbContext.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Album album = dbContext.Albums.Find(id);
            Album album = dbContext.Albums.Include(a => a.Artist).Include(a => a.Genre).Single(a => a.AlbumId == id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);            
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        public ActionResult DeleteConfirmed([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            //Album album = dbContext.Albums.Find(id);
            //dbContext.Albums.Remove(album);
            dbContext.Entry(album).State = EntityState.Deleted;
            dbContext.SaveChanges();
            
            return RedirectToAction("Index");
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
