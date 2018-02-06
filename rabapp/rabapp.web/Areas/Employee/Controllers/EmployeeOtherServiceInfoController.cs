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
    public class EmployeeOtherServiceInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeOtherServiceInfo
        public ActionResult Index()
        {
            var employeeOtherServiceInfoes = db.EmployeeOtherServiceInfoes.Include(e => e.EmployeeInfo);
            return View(employeeOtherServiceInfoes.ToList());
        }

        // GET: Employee/EmployeeOtherServiceInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeOtherServiceInfo employeeOtherServiceInfo = db.EmployeeOtherServiceInfoes.Find(id);
            if (employeeOtherServiceInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeOtherServiceInfo);
        }

        // GET: Employee/EmployeeOtherServiceInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeOtherServiceInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeOtherServiceInfoId,EmployeeInfoId,ServiceTitle,PositionTitle,ServiceTypeTitle,FromDate,ToDate")] EmployeeOtherServiceInfo employeeOtherServiceInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeOtherServiceInfoes.Add(employeeOtherServiceInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeOtherServiceInfo.EmployeeInfoId);
            return View(employeeOtherServiceInfo);
        }

        // GET: Employee/EmployeeOtherServiceInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeOtherServiceInfo employeeOtherServiceInfo = db.EmployeeOtherServiceInfoes.Find(id);
            if (employeeOtherServiceInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeOtherServiceInfo.EmployeeInfoId);
            return View(employeeOtherServiceInfo);
        }

        // POST: Employee/EmployeeOtherServiceInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeOtherServiceInfoId,EmployeeInfoId,ServiceTitle,PositionTitle,ServiceTypeTitle,FromDate,ToDate")] EmployeeOtherServiceInfo employeeOtherServiceInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeOtherServiceInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeOtherServiceInfo.EmployeeInfoId);
            return View(employeeOtherServiceInfo);
        }

        // GET: Employee/EmployeeOtherServiceInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeOtherServiceInfo employeeOtherServiceInfo = db.EmployeeOtherServiceInfoes.Find(id);
            if (employeeOtherServiceInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeOtherServiceInfo);
        }

        // POST: Employee/EmployeeOtherServiceInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeOtherServiceInfo employeeOtherServiceInfo = db.EmployeeOtherServiceInfoes.Find(id);
            db.EmployeeOtherServiceInfoes.Remove(employeeOtherServiceInfo);
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
