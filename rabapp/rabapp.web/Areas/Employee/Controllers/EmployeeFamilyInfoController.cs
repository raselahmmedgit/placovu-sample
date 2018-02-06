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
    public class EmployeeFamilyInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeFamilyInfo
        public ActionResult Index()
        {
            var employeeFamilyInfoes = db.EmployeeFamilyInfoes.Include(e => e.EmployeeInfo);
            return View(employeeFamilyInfoes.ToList());
        }

        // GET: Employee/EmployeeFamilyInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeFamilyInfo employeeFamilyInfo = db.EmployeeFamilyInfoes.Find(id);
            if (employeeFamilyInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeFamilyInfo);
        }

        // GET: Employee/EmployeeFamilyInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeFamilyInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeJobInfoId,EmployeeInfoId,EmployeeSpouseName,EmployeeFatherName,EmployeeMotherName,PrimaryPhone,PrimaryPhoneCode,PrimaryPhoneCountryId,OccupationName,OrganizationName,PresentAddress,PermanantAddress")] EmployeeFamilyInfo employeeFamilyInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeFamilyInfoes.Add(employeeFamilyInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeFamilyInfo.EmployeeInfoId);
            return View(employeeFamilyInfo);
        }

        // GET: Employee/EmployeeFamilyInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeFamilyInfo employeeFamilyInfo = db.EmployeeFamilyInfoes.Find(id);
            if (employeeFamilyInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeFamilyInfo.EmployeeInfoId);
            return View(employeeFamilyInfo);
        }

        // POST: Employee/EmployeeFamilyInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeJobInfoId,EmployeeInfoId,EmployeeSpouseName,EmployeeFatherName,EmployeeMotherName,PrimaryPhone,PrimaryPhoneCode,PrimaryPhoneCountryId,OccupationName,OrganizationName,PresentAddress,PermanantAddress")] EmployeeFamilyInfo employeeFamilyInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeFamilyInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeFamilyInfo.EmployeeInfoId);
            return View(employeeFamilyInfo);
        }

        // GET: Employee/EmployeeFamilyInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeFamilyInfo employeeFamilyInfo = db.EmployeeFamilyInfoes.Find(id);
            if (employeeFamilyInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeFamilyInfo);
        }

        // POST: Employee/EmployeeFamilyInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeFamilyInfo employeeFamilyInfo = db.EmployeeFamilyInfoes.Find(id);
            db.EmployeeFamilyInfoes.Remove(employeeFamilyInfo);
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
