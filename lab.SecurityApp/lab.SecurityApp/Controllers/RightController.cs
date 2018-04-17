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
    public class RightController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Right
        public ActionResult Index()
        {
            return View(db.Rights.ToList());
        }

        // GET: Right/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Right right = db.Rights.Find(id);
            if (right == null)
            {
                return HttpNotFound();
            }
            return View(right);
        }

        // GET: Right/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Right/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RightId,Name,Description")] Right right)
        {
            if (ModelState.IsValid)
            {
                db.Rights.Add(right);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(right);
        }

        // GET: Right/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Right right = db.Rights.Find(id);
            if (right == null)
            {
                return HttpNotFound();
            }
            return View(right);
        }

        // POST: Right/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RightId,Name,Description")] Right right)
        {
            if (ModelState.IsValid)
            {
                db.Entry(right).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(right);
        }

        // GET: Right/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Right right = db.Rights.Find(id);
            if (right == null)
            {
                return HttpNotFound();
            }
            return View(right);
        }

        // POST: Right/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Right right = db.Rights.Find(id);
            db.Rights.Remove(right);
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
