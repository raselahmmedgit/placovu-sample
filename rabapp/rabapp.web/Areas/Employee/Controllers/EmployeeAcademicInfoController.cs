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

namespace rabapp.web.Areas.Employee.Controllers
{
    public class EmployeeAcademicInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeAcademicInfo
        public ActionResult Index()
        {
            var employeeAcademicInfoes = db.EmployeeAcademicInfoes.Include(e => e.EmployeeInfo);
            return View(employeeAcademicInfoes.ToList());
        }

        // GET: Employee/EmployeeAcademicInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAcademicInfo employeeAcademicInfo = db.EmployeeAcademicInfoes.Find(id);
            if (employeeAcademicInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeAcademicInfo);
        }

        // GET: Employee/EmployeeAcademicInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeAcademicInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeAcademicInfoId,EmployeeInfoId,DegreeName,ConcentrationName,InstituteName,BoardUniversityName,GradeMarks,GradeMarksOutOf,GradeMarksPercent,PassingYear")] EmployeeAcademicInfo employeeAcademicInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeAcademicInfoes.Add(employeeAcademicInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeAcademicInfo.EmployeeInfoId);
            return View(employeeAcademicInfo);
        }

        // GET: Employee/EmployeeAcademicInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAcademicInfo employeeAcademicInfo = db.EmployeeAcademicInfoes.Find(id);
            if (employeeAcademicInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeAcademicInfo.EmployeeInfoId);
            return View(employeeAcademicInfo);
        }

        // POST: Employee/EmployeeAcademicInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeAcademicInfoId,EmployeeInfoId,DegreeName,ConcentrationName,InstituteName,BoardUniversityName,GradeMarks,GradeMarksOutOf,GradeMarksPercent,PassingYear")] EmployeeAcademicInfo employeeAcademicInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAcademicInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeAcademicInfo.EmployeeInfoId);
            return View(employeeAcademicInfo);
        }

        // GET: Employee/EmployeeAcademicInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAcademicInfo employeeAcademicInfo = db.EmployeeAcademicInfoes.Find(id);
            if (employeeAcademicInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeAcademicInfo);
        }

        // POST: Employee/EmployeeAcademicInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeAcademicInfo employeeAcademicInfo = db.EmployeeAcademicInfoes.Find(id);
            db.EmployeeAcademicInfoes.Remove(employeeAcademicInfo);
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
