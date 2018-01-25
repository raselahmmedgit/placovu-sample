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
    public class AssignSectionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/AssignSection
        public ActionResult Index()
        {
            var assignSections = db.AssignSections.Include(a => a.Branch).Include(a => a.Department).Include(a => a.Section);
            return View(assignSections.ToList());
        }

        // GET: Admin/AssignSection/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignSection assignSection = db.AssignSections.Find(id);
            if (assignSection == null)
            {
                return HttpNotFound();
            }
            return View(assignSection);
        }

        // GET: Admin/AssignSection/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName");
            return View();
        }

        // POST: Admin/AssignSection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignSectionId,AssignSectionName,BranchId,DepartmentId,SectionId")] AssignSection assignSection)
        {
            if (ModelState.IsValid)
            {
                db.AssignSections.Add(assignSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", assignSection.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", assignSection.DepartmentId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", assignSection.SectionId);
            return View(assignSection);
        }

        // GET: Admin/AssignSection/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignSection assignSection = db.AssignSections.Find(id);
            if (assignSection == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", assignSection.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", assignSection.DepartmentId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", assignSection.SectionId);
            return View(assignSection);
        }

        // POST: Admin/AssignSection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignSectionId,AssignSectionName,BranchId,DepartmentId,SectionId")] AssignSection assignSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", assignSection.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", assignSection.DepartmentId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", assignSection.SectionId);
            return View(assignSection);
        }

        // GET: Admin/AssignSection/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignSection assignSection = db.AssignSections.Find(id);
            if (assignSection == null)
            {
                return HttpNotFound();
            }
            return View(assignSection);
        }

        // POST: Admin/AssignSection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignSection assignSection = db.AssignSections.Find(id);
            db.AssignSections.Remove(assignSection);
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
