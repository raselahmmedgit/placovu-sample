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
    public class EmployeeJobInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeJobInfo
        public ActionResult Index()
        {
            var employeeJobInfoes = db.EmployeeJobInfoes.Include(e => e.Branch).Include(e => e.Department).Include(e => e.Designation).Include(e => e.EmployeeInfo).Include(e => e.EmployeeClassType).Include(e => e.EmployeeJobType).Include(e => e.JoinDesignation).Include(e => e.SalaryGrade).Include(e => e.Section);
            return View(employeeJobInfoes.ToList());
        }

        // GET: Employee/EmployeeJobInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeJobInfo employeeJobInfo = db.EmployeeJobInfoes.Find(id);
            if (employeeJobInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeJobInfo);
        }

        // GET: Employee/EmployeeJobInfo/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName");
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            ViewBag.EmployeeClassTypeId = new SelectList(db.EmployeeClassTypes, "EmployeeClassTypeId", "EmployeeClassTypeName");
            ViewBag.EmployeeJobTypeId = new SelectList(db.EmployeeJobTypes, "EmployeeJobTypeId", "EmployeeJobTypeName");
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName");
            ViewBag.SalaryGradeId = new SelectList(db.SalaryGrades, "SalaryGradeId", "SalaryGradeName");
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName");
            return View();
        }

        // POST: Employee/EmployeeJobInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeJobInfoId,EmployeeInfoId,EmployeeJobTypeId,EmployeeClassTypeId,SalaryGradeId,PresentJoinDate,HouseRent,JoinDesignationId,BranchId,DepartmentId,SectionId,DesignationId")] EmployeeJobInfo employeeJobInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeJobInfoes.Add(employeeJobInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", employeeJobInfo.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeJobInfo.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeJobInfo.DesignationId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeJobInfo.EmployeeInfoId);
            ViewBag.EmployeeClassTypeId = new SelectList(db.EmployeeClassTypes, "EmployeeClassTypeId", "EmployeeClassTypeName", employeeJobInfo.EmployeeClassTypeId);
            ViewBag.EmployeeJobTypeId = new SelectList(db.EmployeeJobTypes, "EmployeeJobTypeId", "EmployeeJobTypeName", employeeJobInfo.EmployeeJobTypeId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeJobInfo.DesignationId);
            ViewBag.SalaryGradeId = new SelectList(db.SalaryGrades, "SalaryGradeId", "SalaryGradeName", employeeJobInfo.SalaryGradeId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", employeeJobInfo.SectionId);
            return View(employeeJobInfo);
        }

        // GET: Employee/EmployeeJobInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeJobInfo employeeJobInfo = db.EmployeeJobInfoes.Find(id);
            if (employeeJobInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", employeeJobInfo.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeJobInfo.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeJobInfo.DesignationId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeJobInfo.EmployeeInfoId);
            ViewBag.EmployeeClassTypeId = new SelectList(db.EmployeeClassTypes, "EmployeeClassTypeId", "EmployeeClassTypeName", employeeJobInfo.EmployeeClassTypeId);
            ViewBag.EmployeeJobTypeId = new SelectList(db.EmployeeJobTypes, "EmployeeJobTypeId", "EmployeeJobTypeName", employeeJobInfo.EmployeeJobTypeId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeJobInfo.DesignationId);
            ViewBag.SalaryGradeId = new SelectList(db.SalaryGrades, "SalaryGradeId", "SalaryGradeName", employeeJobInfo.SalaryGradeId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", employeeJobInfo.SectionId);
            return View(employeeJobInfo);
        }

        // POST: Employee/EmployeeJobInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeJobInfoId,EmployeeInfoId,EmployeeJobTypeId,EmployeeClassTypeId,SalaryGradeId,PresentJoinDate,HouseRent,JoinDesignationId,BranchId,DepartmentId,SectionId,DesignationId")] EmployeeJobInfo employeeJobInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeJobInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", employeeJobInfo.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeJobInfo.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeJobInfo.DesignationId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeJobInfo.EmployeeInfoId);
            ViewBag.EmployeeClassTypeId = new SelectList(db.EmployeeClassTypes, "EmployeeClassTypeId", "EmployeeClassTypeName", employeeJobInfo.EmployeeClassTypeId);
            ViewBag.EmployeeJobTypeId = new SelectList(db.EmployeeJobTypes, "EmployeeJobTypeId", "EmployeeJobTypeName", employeeJobInfo.EmployeeJobTypeId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeJobInfo.DesignationId);
            ViewBag.SalaryGradeId = new SelectList(db.SalaryGrades, "SalaryGradeId", "SalaryGradeName", employeeJobInfo.SalaryGradeId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", employeeJobInfo.SectionId);
            return View(employeeJobInfo);
        }

        // GET: Employee/EmployeeJobInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeJobInfo employeeJobInfo = db.EmployeeJobInfoes.Find(id);
            if (employeeJobInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeJobInfo);
        }

        // POST: Employee/EmployeeJobInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeJobInfo employeeJobInfo = db.EmployeeJobInfoes.Find(id);
            db.EmployeeJobInfoes.Remove(employeeJobInfo);
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
