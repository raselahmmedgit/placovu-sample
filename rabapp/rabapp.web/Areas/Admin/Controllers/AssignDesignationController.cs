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
    public class AssignDesignationController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/AssignDesignation
        public ActionResult Index()
        {
            var assignDesignations = db.AssignDesignations.Include(a => a.Branch).Include(a => a.Department).Include(a => a.Designation).Include(a => a.Section);
            return View(assignDesignations.ToList());
        }

        // GET: Admin/AssignDesignation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignDesignation assignDesignation = db.AssignDesignations.Find(id);
            if (assignDesignation == null)
            {
                return HttpNotFound();
            }
            return View(assignDesignation);
        }

        // GET: Admin/AssignDesignation/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName");
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName");
            return View();
        }

        // POST: Admin/AssignDesignation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignDesignationId,AssignDesignationName,BranchId,DepartmentId,SectionId,DesignationId")] AssignDesignation assignDesignation)
        {
            if (ModelState.IsValid)
            {
                db.AssignDesignations.Add(assignDesignation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", assignDesignation.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", assignDesignation.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", assignDesignation.DesignationId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", assignDesignation.SectionId);
            return View(assignDesignation);
        }

        // GET: Admin/AssignDesignation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignDesignation assignDesignation = db.AssignDesignations.Find(id);
            if (assignDesignation == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", assignDesignation.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", assignDesignation.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", assignDesignation.DesignationId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", assignDesignation.SectionId);
            return View(assignDesignation);
        }

        // POST: Admin/AssignDesignation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignDesignationId,AssignDesignationName,BranchId,DepartmentId,SectionId,DesignationId")] AssignDesignation assignDesignation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignDesignation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", assignDesignation.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", assignDesignation.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", assignDesignation.DesignationId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", assignDesignation.SectionId);
            return View(assignDesignation);
        }

        // GET: Admin/AssignDesignation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignDesignation assignDesignation = db.AssignDesignations.Find(id);
            if (assignDesignation == null)
            {
                return HttpNotFound();
            }
            return View(assignDesignation);
        }

        // POST: Admin/AssignDesignation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignDesignation assignDesignation = db.AssignDesignations.Find(id);
            db.AssignDesignations.Remove(assignDesignation);
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
