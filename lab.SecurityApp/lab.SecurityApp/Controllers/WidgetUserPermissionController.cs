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
    public class WidgetUserPermissionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: WidgetUserPermission
        public ActionResult Index()
        {
            var widgetUserPermissions = db.WidgetUserPermissions.Include(w => w.User).Include(w => w.Widget);
            return View(widgetUserPermissions.ToList());
        }

        // GET: WidgetUserPermission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WidgetUserPermission widgetUserPermission = db.WidgetUserPermissions.Find(id);
            if (widgetUserPermission == null)
            {
                return HttpNotFound();
            }
            return View(widgetUserPermission);
        }

        // GET: WidgetUserPermission/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            ViewBag.WidgetId = new SelectList(db.Widgets, "WidgetId", "Name");
            return View();
        }

        // POST: WidgetUserPermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WidgetPermissionId,IsAdd,IsRemove,WidgetId,UserId")] WidgetUserPermission widgetUserPermission)
        {
            if (ModelState.IsValid)
            {
                db.WidgetUserPermissions.Add(widgetUserPermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", widgetUserPermission.UserId);
            ViewBag.WidgetId = new SelectList(db.Widgets, "WidgetId", "Name", widgetUserPermission.WidgetId);
            return View(widgetUserPermission);
        }

        // GET: WidgetUserPermission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WidgetUserPermission widgetUserPermission = db.WidgetUserPermissions.Find(id);
            if (widgetUserPermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", widgetUserPermission.UserId);
            ViewBag.WidgetId = new SelectList(db.Widgets, "WidgetId", "Name", widgetUserPermission.WidgetId);
            return View(widgetUserPermission);
        }

        // POST: WidgetUserPermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WidgetPermissionId,IsAdd,IsRemove,WidgetId,UserId")] WidgetUserPermission widgetUserPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(widgetUserPermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", widgetUserPermission.UserId);
            ViewBag.WidgetId = new SelectList(db.Widgets, "WidgetId", "Name", widgetUserPermission.WidgetId);
            return View(widgetUserPermission);
        }

        // GET: WidgetUserPermission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WidgetUserPermission widgetUserPermission = db.WidgetUserPermissions.Find(id);
            if (widgetUserPermission == null)
            {
                return HttpNotFound();
            }
            return View(widgetUserPermission);
        }

        // POST: WidgetUserPermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WidgetUserPermission widgetUserPermission = db.WidgetUserPermissions.Find(id);
            db.WidgetUserPermissions.Remove(widgetUserPermission);
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
