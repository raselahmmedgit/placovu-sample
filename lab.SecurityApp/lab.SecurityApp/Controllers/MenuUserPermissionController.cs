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
    public class MenuUserPermissionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: MenuUserPermission
        public ActionResult Index()
        {
            var menuUserPermissions = db.MenuUserPermissions.Include(m => m.Menu).Include(m => m.User);
            return View(menuUserPermissions.ToList());
        }

        // GET: MenuUserPermission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuUserPermission menuUserPermission = db.MenuUserPermissions.Find(id);
            if (menuUserPermission == null)
            {
                return HttpNotFound();
            }
            return View(menuUserPermission);
        }

        // GET: MenuUserPermission/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: MenuUserPermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuUserPermissionId,IsAdd,IsRemove,MenuId,UserId")] MenuUserPermission menuUserPermission)
        {
            if (ModelState.IsValid)
            {
                db.MenuUserPermissions.Add(menuUserPermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuName", menuUserPermission.MenuId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", menuUserPermission.UserId);
            return View(menuUserPermission);
        }

        // GET: MenuUserPermission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuUserPermission menuUserPermission = db.MenuUserPermissions.Find(id);
            if (menuUserPermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuName", menuUserPermission.MenuId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", menuUserPermission.UserId);
            return View(menuUserPermission);
        }

        // POST: MenuUserPermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuUserPermissionId,IsAdd,IsRemove,MenuId,UserId")] MenuUserPermission menuUserPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuUserPermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuName", menuUserPermission.MenuId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", menuUserPermission.UserId);
            return View(menuUserPermission);
        }

        // GET: MenuUserPermission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuUserPermission menuUserPermission = db.MenuUserPermissions.Find(id);
            if (menuUserPermission == null)
            {
                return HttpNotFound();
            }
            return View(menuUserPermission);
        }

        // POST: MenuUserPermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuUserPermission menuUserPermission = db.MenuUserPermissions.Find(id);
            db.MenuUserPermissions.Remove(menuUserPermission);
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
