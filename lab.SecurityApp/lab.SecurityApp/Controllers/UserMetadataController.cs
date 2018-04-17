using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab.SecurityApp.Models;

namespace lab.SecurityApp.Controllers
{
    public class UserMetadataController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: UserMetadata
        public ActionResult Index()
        {
            return View(db.UserMetadatas.ToList());
        }

        // GET: UserMetadata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMetadata userMetadata = db.UserMetadatas.Find(id);
            if (userMetadata == null)
            {
                return HttpNotFound();
            }
            return View(userMetadata);
        }

        // GET: UserMetadata/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserMetadata/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserMetadataId,Name")] UserMetadata userMetadata)
        {
            if (ModelState.IsValid)
            {
                db.UserMetadatas.Add(userMetadata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userMetadata);
        }

        // GET: UserMetadata/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMetadata userMetadata = db.UserMetadatas.Find(id);
            if (userMetadata == null)
            {
                return HttpNotFound();
            }
            return View(userMetadata);
        }

        // POST: UserMetadata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserMetadataId,Name")] UserMetadata userMetadata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMetadata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userMetadata);
        }

        // GET: UserMetadata/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMetadata userMetadata = db.UserMetadatas.Find(id);
            if (userMetadata == null)
            {
                return HttpNotFound();
            }
            return View(userMetadata);
        }

        // POST: UserMetadata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMetadata userMetadata = db.UserMetadatas.Find(id);
            db.UserMetadatas.Remove(userMetadata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
