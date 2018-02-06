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
    public class EmployeeContactInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeContactInfo
        public ActionResult Index()
        {
            var employeeContactInfoes = db.EmployeeContactInfoes.Include(e => e.EmployeeInfo).Include(e => e.ResidentType);
            return View(employeeContactInfoes.ToList());
        }

        // GET: Employee/EmployeeContactInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeContactInfo employeeContactInfo = db.EmployeeContactInfoes.Find(id);
            if (employeeContactInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeContactInfo);
        }

        // GET: Employee/EmployeeContactInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            ViewBag.ResidentTypeId = new SelectList(db.ResidentTypes, "ResidentTypeId", "ResidentTypeName");
            return View();
        }

        // POST: Employee/EmployeeContactInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeContactInfoId,EmployeeInfoId,PresentAddress,PermanantAddress,PostOfficeName,PostalCode,UpazilaName,DistrictName,DivisionName,EmailAddress,PhoneNumber,PhoneNumberCode,PhoneNumberCountryId,MobileNumber,MobileNumberCode,MobileNumberCountryId,ResidentTypeId")] EmployeeContactInfo employeeContactInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeContactInfoes.Add(employeeContactInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeContactInfo.EmployeeInfoId);
            ViewBag.ResidentTypeId = new SelectList(db.ResidentTypes, "ResidentTypeId", "ResidentTypeName", employeeContactInfo.ResidentTypeId);
            return View(employeeContactInfo);
        }

        // GET: Employee/EmployeeContactInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeContactInfo employeeContactInfo = db.EmployeeContactInfoes.Find(id);
            if (employeeContactInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeContactInfo.EmployeeInfoId);
            ViewBag.ResidentTypeId = new SelectList(db.ResidentTypes, "ResidentTypeId", "ResidentTypeName", employeeContactInfo.ResidentTypeId);
            return View(employeeContactInfo);
        }

        // POST: Employee/EmployeeContactInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeContactInfoId,EmployeeInfoId,PresentAddress,PermanantAddress,PostOfficeName,PostalCode,UpazilaName,DistrictName,DivisionName,EmailAddress,PhoneNumber,PhoneNumberCode,PhoneNumberCountryId,MobileNumber,MobileNumberCode,MobileNumberCountryId,ResidentTypeId")] EmployeeContactInfo employeeContactInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeContactInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeContactInfo.EmployeeInfoId);
            ViewBag.ResidentTypeId = new SelectList(db.ResidentTypes, "ResidentTypeId", "ResidentTypeName", employeeContactInfo.ResidentTypeId);
            return View(employeeContactInfo);
        }

        // GET: Employee/EmployeeContactInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeContactInfo employeeContactInfo = db.EmployeeContactInfoes.Find(id);
            if (employeeContactInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeContactInfo);
        }

        // POST: Employee/EmployeeContactInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeContactInfo employeeContactInfo = db.EmployeeContactInfoes.Find(id);
            db.EmployeeContactInfoes.Remove(employeeContactInfo);
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
