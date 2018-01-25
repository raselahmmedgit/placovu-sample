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
    public class JobDurationController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/JobDuration
        public ActionResult Index()
        {
            return View(db.JobDurations.ToList());
        }

        // GET: Admin/JobDuration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobDuration jobDuration = db.JobDurations.Find(id);
            if (jobDuration == null)
            {
                return HttpNotFound();
            }
            return View(jobDuration);
        }

        // GET: Admin/JobDuration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/JobDuration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobDurationId,JobDurationName,JobDurationYear")] JobDuration jobDuration)
        {
            if (ModelState.IsValid)
            {
                db.JobDurations.Add(jobDuration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobDuration);
        }

        // GET: Admin/JobDuration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobDuration jobDuration = db.JobDurations.Find(id);
            if (jobDuration == null)
            {
                return HttpNotFound();
            }
            return View(jobDuration);
        }

        // POST: Admin/JobDuration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobDurationId,JobDurationName,JobDurationYear")] JobDuration jobDuration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobDuration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobDuration);
        }

        // GET: Admin/JobDuration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobDuration jobDuration = db.JobDurations.Find(id);
            if (jobDuration == null)
            {
                return HttpNotFound();
            }
            return View(jobDuration);
        }

        // POST: Admin/JobDuration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobDuration jobDuration = db.JobDurations.Find(id);
            db.JobDurations.Remove(jobDuration);
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
