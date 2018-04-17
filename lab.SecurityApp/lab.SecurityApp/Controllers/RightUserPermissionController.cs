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
    public class RightUserPermissionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: RightUserPermission
        public ActionResult Index()
        {
            var rightUserPermissions = db.RightUserPermissions.Include(r => r.Right).Include(r => r.User);
            return View(rightUserPermissions.ToList());
        }

        // GET: RightUserPermission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RightUserPermission rightUserPermission = db.RightUserPermissions.Find(id);
            if (rightUserPermission == null)
            {
                return HttpNotFound();
            }
            return View(rightUserPermission);
        }

        // GET: RightUserPermission/Create
        public ActionResult Create()
        {
            ViewBag.RightId = new SelectList(db.Rights, "RightId", "Name");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: RightUserPermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RightUserPermissionId,IsAdd,IsRemove,RightId,UserId")] RightUserPermission rightUserPermission)
        {
            if (ModelState.IsValid)
            {
                db.RightUserPermissions.Add(rightUserPermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RightId = new SelectList(db.Rights, "RightId", "Name", rightUserPermission.RightId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", rightUserPermission.UserId);
            return View(rightUserPermission);
        }

        // GET: RightUserPermission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RightUserPermission rightUserPermission = db.RightUserPermissions.Find(id);
            if (rightUserPermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.RightId = new SelectList(db.Rights, "RightId", "Name", rightUserPermission.RightId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", rightUserPermission.UserId);
            return View(rightUserPermission);
        }

        // POST: RightUserPermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RightUserPermissionId,IsAdd,IsRemove,RightId,UserId")] RightUserPermission rightUserPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rightUserPermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RightId = new SelectList(db.Rights, "RightId", "Name", rightUserPermission.RightId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", rightUserPermission.UserId);
            return View(rightUserPermission);
        }

        // GET: RightUserPermission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RightUserPermission rightUserPermission = db.RightUserPermissions.Find(id);
            if (rightUserPermission == null)
            {
                return HttpNotFound();
            }
            return View(rightUserPermission);
        }

        // POST: RightUserPermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RightUserPermission rightUserPermission = db.RightUserPermissions.Find(id);
            db.RightUserPermissions.Remove(rightUserPermission);
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
