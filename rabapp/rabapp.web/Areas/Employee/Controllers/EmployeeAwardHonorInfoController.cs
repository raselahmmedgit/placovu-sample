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
    public class EmployeeAwardHonorInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeAwardHonorInfo
        public ActionResult Index()
        {
            var employeeAwardHonorInfoes = db.EmployeeAwardHonorInfoes.Include(e => e.Country).Include(e => e.EmployeeInfo);
            return View(employeeAwardHonorInfoes.ToList());
        }

        // GET: Employee/EmployeeAwardHonorInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAwardHonorInfo employeeAwardHonorInfo = db.EmployeeAwardHonorInfoes.Find(id);
            if (employeeAwardHonorInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeAwardHonorInfo);
        }

        // GET: Employee/EmployeeAwardHonorInfo/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeAwardHonorInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeAwardHonorInfoId,EmployeeInfoId,AwardHonorTitle,OrganizationName,CountryId,AwardHonorReceiveDate")] EmployeeAwardHonorInfo employeeAwardHonorInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeAwardHonorInfoes.Add(employeeAwardHonorInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", employeeAwardHonorInfo.CountryId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeAwardHonorInfo.EmployeeInfoId);
            return View(employeeAwardHonorInfo);
        }

        // GET: Employee/EmployeeAwardHonorInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAwardHonorInfo employeeAwardHonorInfo = db.EmployeeAwardHonorInfoes.Find(id);
            if (employeeAwardHonorInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", employeeAwardHonorInfo.CountryId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeAwardHonorInfo.EmployeeInfoId);
            return View(employeeAwardHonorInfo);
        }

        // POST: Employee/EmployeeAwardHonorInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeAwardHonorInfoId,EmployeeInfoId,AwardHonorTitle,OrganizationName,CountryId,AwardHonorReceiveDate")] EmployeeAwardHonorInfo employeeAwardHonorInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAwardHonorInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", employeeAwardHonorInfo.CountryId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeAwardHonorInfo.EmployeeInfoId);
            return View(employeeAwardHonorInfo);
        }

        // GET: Employee/EmployeeAwardHonorInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAwardHonorInfo employeeAwardHonorInfo = db.EmployeeAwardHonorInfoes.Find(id);
            if (employeeAwardHonorInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeAwardHonorInfo);
        }

        // POST: Employee/EmployeeAwardHonorInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeAwardHonorInfo employeeAwardHonorInfo = db.EmployeeAwardHonorInfoes.Find(id);
            db.EmployeeAwardHonorInfoes.Remove(employeeAwardHonorInfo);
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
