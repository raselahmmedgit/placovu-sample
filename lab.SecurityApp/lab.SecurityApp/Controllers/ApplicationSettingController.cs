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
    public class ApplicationSettingController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ApplicationSetting
        public ActionResult Index()
        {
            return View(db.ApplicationSettings.ToList());
        }

        // GET: ApplicationSetting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationSetting applicationSetting = db.ApplicationSettings.Find(id);
            if (applicationSetting == null)
            {
                return HttpNotFound();
            }
            return View(applicationSetting);
        }

        // GET: ApplicationSetting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationSetting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationInfoId,Name,Key,Value,Description")] ApplicationSetting applicationSetting)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationSettings.Add(applicationSetting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationSetting);
        }

        // GET: ApplicationSetting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationSetting applicationSetting = db.ApplicationSettings.Find(id);
            if (applicationSetting == null)
            {
                return HttpNotFound();
            }
            return View(applicationSetting);
        }

        // POST: ApplicationSetting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationInfoId,Name,Key,Value,Description")] ApplicationSetting applicationSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationSetting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationSetting);
        }

        // GET: ApplicationSetting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationSetting applicationSetting = db.ApplicationSettings.Find(id);
            if (applicationSetting == null)
            {
                return HttpNotFound();
            }
            return View(applicationSetting);
        }

        // POST: ApplicationSetting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationSetting applicationSetting = db.ApplicationSettings.Find(id);
            db.ApplicationSettings.Remove(applicationSetting);
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
