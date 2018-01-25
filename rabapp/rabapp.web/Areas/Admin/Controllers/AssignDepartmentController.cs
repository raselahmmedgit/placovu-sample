using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rabapp.Models;
using rabapp.web.Models;

namespace rabapp.web.Areas.Admin.Controllers
{
    public class AssignDepartmentController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/AssignDepartment
        public ActionResult Index()
        {
            var assignDepartments = db.AssignDepartments.Include(a => a.Branch).Include(a => a.Department);
            return View(assignDepartments.ToList());
        }

        // GET: Admin/AssignDepartment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignDepartment assignDepartment = db.AssignDepartments.Find(id);
            if (assignDepartment == null)
            {
                return HttpNotFound();
            }
            return View(assignDepartment);
        }

        // GET: Admin/AssignDepartment/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Admin/AssignDepartment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignDepartmentId,AssignDepartmentName,BranchId,DepartmentId")] AssignDepartment assignDepartment)
        {
            if (ModelState.IsValid)
            {
                db.AssignDepartments.Add(assignDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", assignDepartment.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", assignDepartment.DepartmentId);
            return View(assignDepartment);
        }

        // GET: Admin/AssignDepartment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignDepartment assignDepartment = db.AssignDepartments.Find(id);
            if (assignDepartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", assignDepartment.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", assignDepartment.DepartmentId);
            return View(assignDepartment);
        }

        // POST: Admin/AssignDepartment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignDepartmentId,AssignDepartmentName,BranchId,DepartmentId")] AssignDepartment assignDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", assignDepartment.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", assignDepartment.DepartmentId);
            return View(assignDepartment);
        }

        // GET: Admin/AssignDepartment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignDepartment assignDepartment = db.AssignDepartments.Find(id);
            if (assignDepartment == null)
            {
                return HttpNotFound();
            }
            return View(assignDepartment);
        }

        // POST: Admin/AssignDepartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignDepartment assignDepartment = db.AssignDepartments.Find(id);
            db.AssignDepartments.Remove(assignDepartment);
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
