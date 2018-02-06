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
    public class EmployeeGovtServiceInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeGovtServiceInfo
        public ActionResult Index()
        {
            var employeeGovtServiceInfoes = db.EmployeeGovtServiceInfoes.Include(e => e.EmployeeInfo);
            return View(employeeGovtServiceInfoes.ToList());
        }

        // GET: Employee/EmployeeGovtServiceInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGovtServiceInfo employeeGovtServiceInfo = db.EmployeeGovtServiceInfoes.Find(id);
            if (employeeGovtServiceInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeGovtServiceInfo);
        }

        // GET: Employee/EmployeeGovtServiceInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeGovtServiceInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeGovtServiceInfoId,EmployeeInfoId,StartPositionTitle,ServiceSectorName,GovtServiceDate,JoiningDate")] EmployeeGovtServiceInfo employeeGovtServiceInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeGovtServiceInfoes.Add(employeeGovtServiceInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeGovtServiceInfo.EmployeeInfoId);
            return View(employeeGovtServiceInfo);
        }

        // GET: Employee/EmployeeGovtServiceInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGovtServiceInfo employeeGovtServiceInfo = db.EmployeeGovtServiceInfoes.Find(id);
            if (employeeGovtServiceInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeGovtServiceInfo.EmployeeInfoId);
            return View(employeeGovtServiceInfo);
        }

        // POST: Employee/EmployeeGovtServiceInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeGovtServiceInfoId,EmployeeInfoId,StartPositionTitle,ServiceSectorName,GovtServiceDate,JoiningDate")] EmployeeGovtServiceInfo employeeGovtServiceInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeGovtServiceInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeGovtServiceInfo.EmployeeInfoId);
            return View(employeeGovtServiceInfo);
        }

        // GET: Employee/EmployeeGovtServiceInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGovtServiceInfo employeeGovtServiceInfo = db.EmployeeGovtServiceInfoes.Find(id);
            if (employeeGovtServiceInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeGovtServiceInfo);
        }

        // POST: Employee/EmployeeGovtServiceInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeGovtServiceInfo employeeGovtServiceInfo = db.EmployeeGovtServiceInfoes.Find(id);
            db.EmployeeGovtServiceInfoes.Remove(employeeGovtServiceInfo);
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
