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
    public class DocumentInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: DocumentInfo
        public ActionResult Index()
        {
            var documentInfoes = db.DocumentInfoes.Include(d => d.DocumentInfoType);
            return View(documentInfoes.ToList());
        }

        // GET: DocumentInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentInfo documentInfo = db.DocumentInfoes.Find(id);
            if (documentInfo == null)
            {
                return HttpNotFound();
            }
            return View(documentInfo);
        }

        // GET: DocumentInfo/Create
        public ActionResult Create()
        {
            ViewBag.DocumentInfoTypeId = new SelectList(db.DocumentInfoTypes, "DocumentInfoTypeId", "Name");
            return View();
        }

        // POST: DocumentInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentInfoId,DocumentType,DocumentName,DocumentPath,DocumentContentType,DocumentLength,DocumentContent,DocumentUploadDate,IsTemporary,DocumentInfoTypeId")] DocumentInfo documentInfo)
        {
            if (ModelState.IsValid)
            {
                db.DocumentInfoes.Add(documentInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentInfoTypeId = new SelectList(db.DocumentInfoTypes, "DocumentInfoTypeId", "Name", documentInfo.DocumentInfoTypeId);
            return View(documentInfo);
        }

        // GET: DocumentInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentInfo documentInfo = db.DocumentInfoes.Find(id);
            if (documentInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentInfoTypeId = new SelectList(db.DocumentInfoTypes, "DocumentInfoTypeId", "Name", documentInfo.DocumentInfoTypeId);
            return View(documentInfo);
        }

        // POST: DocumentInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentInfoId,DocumentType,DocumentName,DocumentPath,DocumentContentType,DocumentLength,DocumentContent,DocumentUploadDate,IsTemporary,DocumentInfoTypeId")] DocumentInfo documentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentInfoTypeId = new SelectList(db.DocumentInfoTypes, "DocumentInfoTypeId", "Name", documentInfo.DocumentInfoTypeId);
            return View(documentInfo);
        }

        // GET: DocumentInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentInfo documentInfo = db.DocumentInfoes.Find(id);
            if (documentInfo == null)
            {
                return HttpNotFound();
            }
            return View(documentInfo);
        }

        // POST: DocumentInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentInfo documentInfo = db.DocumentInfoes.Find(id);
            db.DocumentInfoes.Remove(documentInfo);
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
