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
    public class AttendStatusController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/AttendStatus
        public ActionResult Index()
        {
            return View(db.AttendStatus.ToList());
        }

        // GET: Admin/AttendStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendStatus attendStatus = db.AttendStatus.Find(id);
            if (attendStatus == null)
            {
                return HttpNotFound();
            }
            return View(attendStatus);
        }

        // GET: Admin/AttendStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AttendStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttendStatusId,AttendStatusName")] AttendStatus attendStatus)
        {
            if (ModelState.IsValid)
            {
                db.AttendStatus.Add(attendStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendStatus);
        }

        // GET: Admin/AttendStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendStatus attendStatus = db.AttendStatus.Find(id);
            if (attendStatus == null)
            {
                return HttpNotFound();
            }
            return View(attendStatus);
        }

        // POST: Admin/AttendStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendStatusId,AttendStatusName")] AttendStatus attendStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendStatus);
        }

        // GET: Admin/AttendStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendStatus attendStatus = db.AttendStatus.Find(id);
            if (attendStatus == null)
            {
                return HttpNotFound();
            }
            return View(attendStatus);
        }

        // POST: Admin/AttendStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttendStatus attendStatus = db.AttendStatus.Find(id);
            db.AttendStatus.Remove(attendStatus);
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
