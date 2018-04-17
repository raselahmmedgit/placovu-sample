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
    public class RightRolePermissionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: RightRolePermission
        public ActionResult Index()
        {
            var rightRolePermissions = db.RightRolePermissions.Include(r => r.Right).Include(r => r.Role);
            return View(rightRolePermissions.ToList());
        }

        // GET: RightRolePermission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RightRolePermission rightRolePermission = db.RightRolePermissions.Find(id);
            if (rightRolePermission == null)
            {
                return HttpNotFound();
            }
            return View(rightRolePermission);
        }

        // GET: RightRolePermission/Create
        public ActionResult Create()
        {
            ViewBag.RightId = new SelectList(db.Rights, "RightId", "Name");
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: RightRolePermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RightRolePermissionId,RightId,RoleId")] RightRolePermission rightRolePermission)
        {
            if (ModelState.IsValid)
            {
                db.RightRolePermissions.Add(rightRolePermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RightId = new SelectList(db.Rights, "RightId", "Name", rightRolePermission.RightId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", rightRolePermission.RoleId);
            return View(rightRolePermission);
        }

        // GET: RightRolePermission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RightRolePermission rightRolePermission = db.RightRolePermissions.Find(id);
            if (rightRolePermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.RightId = new SelectList(db.Rights, "RightId", "Name", rightRolePermission.RightId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", rightRolePermission.RoleId);
            return View(rightRolePermission);
        }

        // POST: RightRolePermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RightRolePermissionId,RightId,RoleId")] RightRolePermission rightRolePermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rightRolePermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RightId = new SelectList(db.Rights, "RightId", "Name", rightRolePermission.RightId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", rightRolePermission.RoleId);
            return View(rightRolePermission);
        }

        // GET: RightRolePermission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RightRolePermission rightRolePermission = db.RightRolePermissions.Find(id);
            if (rightRolePermission == null)
            {
                return HttpNotFound();
            }
            return View(rightRolePermission);
        }

        // POST: RightRolePermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RightRolePermission rightRolePermission = db.RightRolePermissions.Find(id);
            db.RightRolePermissions.Remove(rightRolePermission);
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
