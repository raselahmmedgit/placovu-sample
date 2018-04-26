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
    public class ApplicationInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ApplicationInfo
        public ActionResult Index()
        {
            return View(db.ApplicationInfos.ToList());
        }

        // GET: ApplicationInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationInfo applicationInfo = db.ApplicationInfos.Find(id);
            if (applicationInfo == null)
            {
                return HttpNotFound();
            }
            return View(applicationInfo);
        }

        // GET: ApplicationInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationInfoId,Name,Key,Value,Description")] ApplicationInfo applicationInfo)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationInfos.Add(applicationInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationInfo);
        }

        // GET: ApplicationInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationInfo applicationInfo = db.ApplicationInfos.Find(id);
            if (applicationInfo == null)
            {
                return HttpNotFound();
            }
            return View(applicationInfo);
        }

        // POST: ApplicationInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationInfoId,Name,Key,Value,Description")] ApplicationInfo applicationInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationInfo);
        }

        // GET: ApplicationInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationInfo applicationInfo = db.ApplicationInfos.Find(id);
            if (applicationInfo == null)
            {
                return HttpNotFound();
            }
            return View(applicationInfo);
        }

        // POST: ApplicationInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationInfo applicationInfo = db.ApplicationInfos.Find(id);
            db.ApplicationInfos.Remove(applicationInfo);
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
