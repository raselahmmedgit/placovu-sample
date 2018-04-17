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
    public class UserActivityController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: UserActivity
        public ActionResult Index()
        {
            return View(db.UserActivities.ToList());
        }

        // GET: UserActivity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserActivity userActivity = db.UserActivities.Find(id);
            if (userActivity == null)
            {
                return HttpNotFound();
            }
            return View(userActivity);
        }

        // GET: UserActivity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserActivity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserActivityId,Name")] UserActivity userActivity)
        {
            if (ModelState.IsValid)
            {
                db.UserActivities.Add(userActivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userActivity);
        }

        // GET: UserActivity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserActivity userActivity = db.UserActivities.Find(id);
            if (userActivity == null)
            {
                return HttpNotFound();
            }
            return View(userActivity);
        }

        // POST: UserActivity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserActivityId,Name")] UserActivity userActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userActivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userActivity);
        }

        // GET: UserActivity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserActivity userActivity = db.UserActivities.Find(id);
            if (userActivity == null)
            {
                return HttpNotFound();
            }
            return View(userActivity);
        }

        // POST: UserActivity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserActivity userActivity = db.UserActivities.Find(id);
            db.UserActivities.Remove(userActivity);
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
