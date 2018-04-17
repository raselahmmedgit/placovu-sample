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
    public class MenuRolePermissionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: MenuRolePermission
        public ActionResult Index()
        {
            var menuRolePermissions = db.MenuRolePermissions.Include(m => m.Menu).Include(m => m.Role);
            return View(menuRolePermissions.ToList());
        }

        // GET: MenuRolePermission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuRolePermission menuRolePermission = db.MenuRolePermissions.Find(id);
            if (menuRolePermission == null)
            {
                return HttpNotFound();
            }
            return View(menuRolePermission);
        }

        // GET: MenuRolePermission/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuName");
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: MenuRolePermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuRolePermissionId,MenuId,RoleId")] MenuRolePermission menuRolePermission)
        {
            if (ModelState.IsValid)
            {
                db.MenuRolePermissions.Add(menuRolePermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuName", menuRolePermission.MenuId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", menuRolePermission.RoleId);
            return View(menuRolePermission);
        }

        // GET: MenuRolePermission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuRolePermission menuRolePermission = db.MenuRolePermissions.Find(id);
            if (menuRolePermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuName", menuRolePermission.MenuId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", menuRolePermission.RoleId);
            return View(menuRolePermission);
        }

        // POST: MenuRolePermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuRolePermissionId,MenuId,RoleId")] MenuRolePermission menuRolePermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuRolePermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(db.Menus, "MenuId", "MenuName", menuRolePermission.MenuId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", menuRolePermission.RoleId);
            return View(menuRolePermission);
        }

        // GET: MenuRolePermission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuRolePermission menuRolePermission = db.MenuRolePermissions.Find(id);
            if (menuRolePermission == null)
            {
                return HttpNotFound();
            }
            return View(menuRolePermission);
        }

        // POST: MenuRolePermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuRolePermission menuRolePermission = db.MenuRolePermissions.Find(id);
            db.MenuRolePermissions.Remove(menuRolePermission);
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
