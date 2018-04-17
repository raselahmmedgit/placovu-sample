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
    public class WidgetCategoryController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: WidgetCategory
        public ActionResult Index()
        {
            return View(db.WidgetCategories.ToList());
        }

        // GET: WidgetCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WidgetCategory widgetCategory = db.WidgetCategories.Find(id);
            if (widgetCategory == null)
            {
                return HttpNotFound();
            }
            return View(widgetCategory);
        }

        // GET: WidgetCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WidgetCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WidgetCategoryId,Name")] WidgetCategory widgetCategory)
        {
            if (ModelState.IsValid)
            {
                db.WidgetCategories.Add(widgetCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(widgetCategory);
        }

        // GET: WidgetCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WidgetCategory widgetCategory = db.WidgetCategories.Find(id);
            if (widgetCategory == null)
            {
                return HttpNotFound();
            }
            return View(widgetCategory);
        }

        // POST: WidgetCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WidgetCategoryId,Name")] WidgetCategory widgetCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(widgetCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(widgetCategory);
        }

        // GET: WidgetCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WidgetCategory widgetCategory = db.WidgetCategories.Find(id);
            if (widgetCategory == null)
            {
                return HttpNotFound();
            }
            return View(widgetCategory);
        }

        // POST: WidgetCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WidgetCategory widgetCategory = db.WidgetCategories.Find(id);
            db.WidgetCategories.Remove(widgetCategory);
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
