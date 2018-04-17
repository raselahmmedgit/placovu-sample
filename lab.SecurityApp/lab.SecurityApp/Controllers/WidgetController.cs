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
    public class WidgetController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Widget
        public ActionResult Index()
        {
            var widgets = db.Widgets.Include(w => w.WidgetCategory);
            return View(widgets.ToList());
        }

        // GET: Widget/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Widget widget = db.Widgets.Find(id);
            if (widget == null)
            {
                return HttpNotFound();
            }
            return View(widget);
        }

        // GET: Widget/Create
        public ActionResult Create()
        {
            ViewBag.WidgetCategoryId = new SelectList(db.WidgetCategories, "WidgetCategoryId", "Name");
            return View();
        }

        // POST: Widget/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WidgetId,Name,IsAdmin,IsShared,WidgetCategoryId")] Widget widget)
        {
            if (ModelState.IsValid)
            {
                db.Widgets.Add(widget);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WidgetCategoryId = new SelectList(db.WidgetCategories, "WidgetCategoryId", "Name", widget.WidgetCategoryId);
            return View(widget);
        }

        // GET: Widget/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Widget widget = db.Widgets.Find(id);
            if (widget == null)
            {
                return HttpNotFound();
            }
            ViewBag.WidgetCategoryId = new SelectList(db.WidgetCategories, "WidgetCategoryId", "Name", widget.WidgetCategoryId);
            return View(widget);
        }

        // POST: Widget/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WidgetId,Name,IsAdmin,IsShared,WidgetCategoryId")] Widget widget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(widget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WidgetCategoryId = new SelectList(db.WidgetCategories, "WidgetCategoryId", "Name", widget.WidgetCategoryId);
            return View(widget);
        }

        // GET: Widget/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Widget widget = db.Widgets.Find(id);
            if (widget == null)
            {
                return HttpNotFound();
            }
            return View(widget);
        }

        // POST: Widget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Widget widget = db.Widgets.Find(id);
            db.Widgets.Remove(widget);
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
