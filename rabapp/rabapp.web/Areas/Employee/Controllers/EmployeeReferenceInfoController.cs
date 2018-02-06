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
    public class EmployeeReferenceInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeReferenceInfo
        public ActionResult Index()
        {
            var employeeReferenceInfoes = db.EmployeeReferenceInfoes.Include(e => e.EmployeeInfo);
            return View(employeeReferenceInfoes.ToList());
        }

        // GET: Employee/EmployeeReferenceInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeReferenceInfo employeeReferenceInfo = db.EmployeeReferenceInfoes.Find(id);
            if (employeeReferenceInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeReferenceInfo);
        }

        // GET: Employee/EmployeeReferenceInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeReferenceInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeReferenceInfoId,EmployeeInfoId,ReferenceName,ReferenceAddress,DesignationTitle,OrganizationName,EmailAddress,PhoneNumber,PhoneNumberCode,PhoneNumberCountryId,MobileNumber,MobileNumberCode,MobileNumberCountryId")] EmployeeReferenceInfo employeeReferenceInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeReferenceInfoes.Add(employeeReferenceInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeReferenceInfo.EmployeeInfoId);
            return View(employeeReferenceInfo);
        }

        // GET: Employee/EmployeeReferenceInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeReferenceInfo employeeReferenceInfo = db.EmployeeReferenceInfoes.Find(id);
            if (employeeReferenceInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeReferenceInfo.EmployeeInfoId);
            return View(employeeReferenceInfo);
        }

        // POST: Employee/EmployeeReferenceInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeReferenceInfoId,EmployeeInfoId,ReferenceName,ReferenceAddress,DesignationTitle,OrganizationName,EmailAddress,PhoneNumber,PhoneNumberCode,PhoneNumberCountryId,MobileNumber,MobileNumberCode,MobileNumberCountryId")] EmployeeReferenceInfo employeeReferenceInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeReferenceInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeReferenceInfo.EmployeeInfoId);
            return View(employeeReferenceInfo);
        }

        // GET: Employee/EmployeeReferenceInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeReferenceInfo employeeReferenceInfo = db.EmployeeReferenceInfoes.Find(id);
            if (employeeReferenceInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeReferenceInfo);
        }

        // POST: Employee/EmployeeReferenceInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeReferenceInfo employeeReferenceInfo = db.EmployeeReferenceInfoes.Find(id);
            db.EmployeeReferenceInfoes.Remove(employeeReferenceInfo);
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
