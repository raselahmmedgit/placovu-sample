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
    public class WeekEndController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/WeekEnd
        public ActionResult Index()
        {
            var weekEnds = db.WeekEnds.Include(w => w.Branch).Include(w => w.WeekDay).Include(w => w.WeekEndType);
            return View(weekEnds.ToList());
        }

        // GET: Admin/WeekEnd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekEnd weekEnd = db.WeekEnds.Find(id);
            if (weekEnd == null)
            {
                return HttpNotFound();
            }
            return View(weekEnd);
        }

        // GET: Admin/WeekEnd/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName");
            ViewBag.WeekDayId = new SelectList(db.WeekDays, "WeekDayId", "WeekDayName");
            ViewBag.WeekEndTypeId = new SelectList(db.WeekEndTypes, "WeekEndTypeId", "WeekEndTypeName");
            return View();
        }

        // POST: Admin/WeekEnd/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeekEndId,WeekEndName,BranchId,WeekEndTypeId,WeekDayId")] WeekEnd weekEnd)
        {
            if (ModelState.IsValid)
            {
                db.WeekEnds.Add(weekEnd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", weekEnd.BranchId);
            ViewBag.WeekDayId = new SelectList(db.WeekDays, "WeekDayId", "WeekDayName", weekEnd.WeekDayId);
            ViewBag.WeekEndTypeId = new SelectList(db.WeekEndTypes, "WeekEndTypeId", "WeekEndTypeName", weekEnd.WeekEndTypeId);
            return View(weekEnd);
        }

        // GET: Admin/WeekEnd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekEnd weekEnd = db.WeekEnds.Find(id);
            if (weekEnd == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", weekEnd.BranchId);
            ViewBag.WeekDayId = new SelectList(db.WeekDays, "WeekDayId", "WeekDayName", weekEnd.WeekDayId);
            ViewBag.WeekEndTypeId = new SelectList(db.WeekEndTypes, "WeekEndTypeId", "WeekEndTypeName", weekEnd.WeekEndTypeId);
            return View(weekEnd);
        }

        // POST: Admin/WeekEnd/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeekEndId,WeekEndName,BranchId,WeekEndTypeId,WeekDayId")] WeekEnd weekEnd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weekEnd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", weekEnd.BranchId);
            ViewBag.WeekDayId = new SelectList(db.WeekDays, "WeekDayId", "WeekDayName", weekEnd.WeekDayId);
            ViewBag.WeekEndTypeId = new SelectList(db.WeekEndTypes, "WeekEndTypeId", "WeekEndTypeName", weekEnd.WeekEndTypeId);
            return View(weekEnd);
        }

        // GET: Admin/WeekEnd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekEnd weekEnd = db.WeekEnds.Find(id);
            if (weekEnd == null)
            {
                return HttpNotFound();
            }
            return View(weekEnd);
        }

        // POST: Admin/WeekEnd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeekEnd weekEnd = db.WeekEnds.Find(id);
            db.WeekEnds.Remove(weekEnd);
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
