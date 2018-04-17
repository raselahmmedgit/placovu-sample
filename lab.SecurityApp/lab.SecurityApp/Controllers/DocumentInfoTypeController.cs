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
    public class DocumentInfoTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: DocumentInfoType
        public ActionResult Index()
        {
            return View(db.DocumentInfoTypes.ToList());
        }

        // GET: DocumentInfoType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentInfoType documentInfoType = db.DocumentInfoTypes.Find(id);
            if (documentInfoType == null)
            {
                return HttpNotFound();
            }
            return View(documentInfoType);
        }

        // GET: DocumentInfoType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentInfoType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentInfoTypeId,Name")] DocumentInfoType documentInfoType)
        {
            if (ModelState.IsValid)
            {
                db.DocumentInfoTypes.Add(documentInfoType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(documentInfoType);
        }

        // GET: DocumentInfoType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentInfoType documentInfoType = db.DocumentInfoTypes.Find(id);
            if (documentInfoType == null)
            {
                return HttpNotFound();
            }
            return View(documentInfoType);
        }

        // POST: DocumentInfoType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentInfoTypeId,Name")] DocumentInfoType documentInfoType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentInfoType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documentInfoType);
        }

        // GET: DocumentInfoType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentInfoType documentInfoType = db.DocumentInfoTypes.Find(id);
            if (documentInfoType == null)
            {
                return HttpNotFound();
            }
            return View(documentInfoType);
        }

        // POST: DocumentInfoType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentInfoType documentInfoType = db.DocumentInfoTypes.Find(id);
            db.DocumentInfoTypes.Remove(documentInfoType);
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
