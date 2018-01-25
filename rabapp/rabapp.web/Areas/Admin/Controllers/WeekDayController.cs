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
    public class WeekDayController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/WeekDay
        public ActionResult Index()
        {
            return View(db.WeekDays.ToList());
        }

        // GET: Admin/WeekDay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekDay weekDay = db.WeekDays.Find(id);
            if (weekDay == null)
            {
                return HttpNotFound();
            }
            return View(weekDay);
        }

        // GET: Admin/WeekDay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/WeekDay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeekDayId,WeekDayName")] WeekDay weekDay)
        {
            if (ModelState.IsValid)
            {
                db.WeekDays.Add(weekDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weekDay);
        }

        // GET: Admin/WeekDay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekDay weekDay = db.WeekDays.Find(id);
            if (weekDay == null)
            {
                return HttpNotFound();
            }
            return View(weekDay);
        }

        // POST: Admin/WeekDay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeekDayId,WeekDayName")] WeekDay weekDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weekDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weekDay);
        }

        // GET: Admin/WeekDay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekDay weekDay = db.WeekDays.Find(id);
            if (weekDay == null)
            {
                return HttpNotFound();
            }
            return View(weekDay);
        }

        // POST: Admin/WeekDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeekDay weekDay = db.WeekDays.Find(id);
            db.WeekDays.Remove(weekDay);
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
