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
    public class EmployeeNomineeInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeNomineeInfo
        public ActionResult Index()
        {
            var employeeNomineeInfoes = db.EmployeeNomineeInfoes.Include(e => e.EmployeeInfo);
            return View(employeeNomineeInfoes.ToList());
        }

        // GET: Employee/EmployeeNomineeInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeNomineeInfo employeeNomineeInfo = db.EmployeeNomineeInfoes.Find(id);
            if (employeeNomineeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeNomineeInfo);
        }

        // GET: Employee/EmployeeNomineeInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeNomineeInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeNomineeInfoId,EmployeeInfoId,NomineeName,NomineeFatherName,NomineeMotherName,NomineeSpouseName,PhoneNumber,PhoneNumberCode,PhoneNumberCountryId,EmailAddress,NationalIDNumber,PassportNumber,PresentAddress,PermanantAddress")] EmployeeNomineeInfo employeeNomineeInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeNomineeInfoes.Add(employeeNomineeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeNomineeInfo.EmployeeInfoId);
            return View(employeeNomineeInfo);
        }

        // GET: Employee/EmployeeNomineeInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeNomineeInfo employeeNomineeInfo = db.EmployeeNomineeInfoes.Find(id);
            if (employeeNomineeInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeNomineeInfo.EmployeeInfoId);
            return View(employeeNomineeInfo);
        }

        // POST: Employee/EmployeeNomineeInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeNomineeInfoId,EmployeeInfoId,NomineeName,NomineeFatherName,NomineeMotherName,NomineeSpouseName,PhoneNumber,PhoneNumberCode,PhoneNumberCountryId,EmailAddress,NationalIDNumber,PassportNumber,PresentAddress,PermanantAddress")] EmployeeNomineeInfo employeeNomineeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeNomineeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeNomineeInfo.EmployeeInfoId);
            return View(employeeNomineeInfo);
        }

        // GET: Employee/EmployeeNomineeInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeNomineeInfo employeeNomineeInfo = db.EmployeeNomineeInfoes.Find(id);
            if (employeeNomineeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeNomineeInfo);
        }

        // POST: Employee/EmployeeNomineeInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeNomineeInfo employeeNomineeInfo = db.EmployeeNomineeInfoes.Find(id);
            db.EmployeeNomineeInfoes.Remove(employeeNomineeInfo);
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
