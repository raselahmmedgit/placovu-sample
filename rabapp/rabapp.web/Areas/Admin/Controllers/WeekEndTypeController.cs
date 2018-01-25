using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rabapp.Models;
using rabapp.web.Models;

namespace rabapp.web.Areas.Admin.Controllers
{
    public class WeekEndTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/WeekEndType
        public ActionResult Index()
        {
            return View(db.WeekEndTypes.ToList());
        }

        // GET: Admin/WeekEndType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekEndType weekEndType = db.WeekEndTypes.Find(id);
            if (weekEndType == null)
            {
                return HttpNotFound();
            }
            return View(weekEndType);
        }

        // GET: Admin/WeekEndType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/WeekEndType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeekEndTypeId,WeekEndTypeName")] WeekEndType weekEndType)
        {
            if (ModelState.IsValid)
            {
                db.WeekEndTypes.Add(weekEndType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weekEndType);
        }

        // GET: Admin/WeekEndType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekEndType weekEndType = db.WeekEndTypes.Find(id);
            if (weekEndType == null)
            {
                return HttpNotFound();
            }
            return View(weekEndType);
        }

        // POST: Admin/WeekEndType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeekEndTypeId,WeekEndTypeName")] WeekEndType weekEndType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weekEndType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weekEndType);
        }

        // GET: Admin/WeekEndType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekEndType weekEndType = db.WeekEndTypes.Find(id);
            if (weekEndType == null)
            {
                return HttpNotFound();
            }
            return View(weekEndType);
        }

        // POST: Admin/WeekEndType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeekEndType weekEndType = db.WeekEndTypes.Find(id);
            db.WeekEndTypes.Remove(weekEndType);
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
