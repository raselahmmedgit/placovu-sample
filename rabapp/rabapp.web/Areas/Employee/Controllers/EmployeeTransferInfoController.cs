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
    public class EmployeeTransferInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeTransferInfo
        public ActionResult Index()
        {
            var employeeTransferInfoes = db.EmployeeTransferInfoes.Include(e => e.Branch).Include(e => e.Department).Include(e => e.Designation).Include(e => e.EmployeeInfo).Include(e => e.Section);
            return View(employeeTransferInfoes.ToList());
        }

        // GET: Employee/EmployeeTransferInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTransferInfo employeeTransferInfo = db.EmployeeTransferInfoes.Find(id);
            if (employeeTransferInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeTransferInfo);
        }

        // GET: Employee/EmployeeTransferInfo/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName");
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName");
            return View();
        }

        // POST: Employee/EmployeeTransferInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeTransferInfoId,EmployeeInfoId,BranchId,DepartmentId,SectionId,DesignationId,IssueDate,FromDate,ToDate,DurationDate,Remarks")] EmployeeTransferInfo employeeTransferInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTransferInfoes.Add(employeeTransferInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", employeeTransferInfo.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeTransferInfo.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeTransferInfo.DesignationId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeTransferInfo.EmployeeInfoId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", employeeTransferInfo.SectionId);
            return View(employeeTransferInfo);
        }

        // GET: Employee/EmployeeTransferInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTransferInfo employeeTransferInfo = db.EmployeeTransferInfoes.Find(id);
            if (employeeTransferInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", employeeTransferInfo.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeTransferInfo.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeTransferInfo.DesignationId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeTransferInfo.EmployeeInfoId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", employeeTransferInfo.SectionId);
            return View(employeeTransferInfo);
        }

        // POST: Employee/EmployeeTransferInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeTransferInfoId,EmployeeInfoId,BranchId,DepartmentId,SectionId,DesignationId,IssueDate,FromDate,ToDate,DurationDate,Remarks")] EmployeeTransferInfo employeeTransferInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTransferInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", employeeTransferInfo.BranchId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeTransferInfo.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeTransferInfo.DesignationId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeTransferInfo.EmployeeInfoId);
            ViewBag.SectionId = new SelectList(db.Sections, "SectionId", "SectionName", employeeTransferInfo.SectionId);
            return View(employeeTransferInfo);
        }

        // GET: Employee/EmployeeTransferInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTransferInfo employeeTransferInfo = db.EmployeeTransferInfoes.Find(id);
            if (employeeTransferInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeTransferInfo);
        }

        // POST: Employee/EmployeeTransferInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeTransferInfo employeeTransferInfo = db.EmployeeTransferInfoes.Find(id);
            db.EmployeeTransferInfoes.Remove(employeeTransferInfo);
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
