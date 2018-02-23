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
    public class EmployeeAttendInfoeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeAttendInfoe
        public ActionResult Index()
        {
            var employeeAttendInfoes = db.EmployeeAttendInfoes.Include(e => e.AttendStatus).Include(e => e.EmployeeInfo);
            return View(employeeAttendInfoes.ToList());
        }

        // GET: Employee/EmployeeAttendInfoe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAttendInfo employeeAttendInfo = db.EmployeeAttendInfoes.Find(id);
            if (employeeAttendInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeAttendInfo);
        }

        // GET: Employee/EmployeeAttendInfoe/Create
        public ActionResult Create()
        {
            ViewBag.AttendStatusId = new SelectList(db.AttendStatus, "AttendStatusId", "AttendStatusName");
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeAttendInfoe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeAttendInfoId,EmployeeInfoId,InTime,OutTime,InDate,OutDate,Location,Notes,AttendStatusId")] EmployeeAttendInfo employeeAttendInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeAttendInfoes.Add(employeeAttendInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttendStatusId = new SelectList(db.AttendStatus, "AttendStatusId", "AttendStatusName", employeeAttendInfo.AttendStatusId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeAttendInfo.EmployeeInfoId);
            return View(employeeAttendInfo);
        }

        // GET: Employee/EmployeeAttendInfoe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAttendInfo employeeAttendInfo = db.EmployeeAttendInfoes.Find(id);
            if (employeeAttendInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttendStatusId = new SelectList(db.AttendStatus, "AttendStatusId", "AttendStatusName", employeeAttendInfo.AttendStatusId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeAttendInfo.EmployeeInfoId);
            return View(employeeAttendInfo);
        }

        // POST: Employee/EmployeeAttendInfoe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeAttendInfoId,EmployeeInfoId,InTime,OutTime,InDate,OutDate,Location,Notes,AttendStatusId")] EmployeeAttendInfo employeeAttendInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAttendInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttendStatusId = new SelectList(db.AttendStatus, "AttendStatusId", "AttendStatusName", employeeAttendInfo.AttendStatusId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeAttendInfo.EmployeeInfoId);
            return View(employeeAttendInfo);
        }

        // GET: Employee/EmployeeAttendInfoe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAttendInfo employeeAttendInfo = db.EmployeeAttendInfoes.Find(id);
            if (employeeAttendInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeAttendInfo);
        }

        // POST: Employee/EmployeeAttendInfoe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeAttendInfo employeeAttendInfo = db.EmployeeAttendInfoes.Find(id);
            db.EmployeeAttendInfoes.Remove(employeeAttendInfo);
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
