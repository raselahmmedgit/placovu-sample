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
    public class WidgetRolePermissionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: WidgetRolePermission
        public ActionResult Index()
        {
            var widgetRolePermissions = db.WidgetRolePermissions.Include(w => w.Role).Include(w => w.Widget);
            return View(widgetRolePermissions.ToList());
        }

        // GET: WidgetRolePermission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WidgetRolePermission widgetRolePermission = db.WidgetRolePermissions.Find(id);
            if (widgetRolePermission == null)
            {
                return HttpNotFound();
            }
            return View(widgetRolePermission);
        }

        // GET: WidgetRolePermission/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            ViewBag.WidgetId = new SelectList(db.Widgets, "WidgetId", "Name");
            return View();
        }

        // POST: WidgetRolePermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WidgetPermissionId,WidgetId,RoleId")] WidgetRolePermission widgetRolePermission)
        {
            if (ModelState.IsValid)
            {
                db.WidgetRolePermissions.Add(widgetRolePermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", widgetRolePermission.RoleId);
            ViewBag.WidgetId = new SelectList(db.Widgets, "WidgetId", "Name", widgetRolePermission.WidgetId);
            return View(widgetRolePermission);
        }

        // GET: WidgetRolePermission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WidgetRolePermission widgetRolePermission = db.WidgetRolePermissions.Find(id);
            if (widgetRolePermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", widgetRolePermission.RoleId);
            ViewBag.WidgetId = new SelectList(db.Widgets, "WidgetId", "Name", widgetRolePermission.WidgetId);
            return View(widgetRolePermission);
        }

        // POST: WidgetRolePermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WidgetPermissionId,WidgetId,RoleId")] WidgetRolePermission widgetRolePermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(widgetRolePermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", widgetRolePermission.RoleId);
            ViewBag.WidgetId = new SelectList(db.Widgets, "WidgetId", "Name", widgetRolePermission.WidgetId);
            return View(widgetRolePermission);
        }

        // GET: WidgetRolePermission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WidgetRolePermission widgetRolePermission = db.WidgetRolePermissions.Find(id);
            if (widgetRolePermission == null)
            {
                return HttpNotFound();
            }
            return View(widgetRolePermission);
        }

        // POST: WidgetRolePermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WidgetRolePermission widgetRolePermission = db.WidgetRolePermissions.Find(id);
            db.WidgetRolePermissions.Remove(widgetRolePermission);
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
