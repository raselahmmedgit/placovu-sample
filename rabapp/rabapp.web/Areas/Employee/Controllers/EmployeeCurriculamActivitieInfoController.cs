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
    public class EmployeeCurriculamActivitieInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeCurriculamActivitieInfo
        public ActionResult Index()
        {
            var employeeCurriculamActivitieInfoes = db.EmployeeCurriculamActivitieInfoes.Include(e => e.EmployeeInfo);
            return View(employeeCurriculamActivitieInfoes.ToList());
        }

        // GET: Employee/EmployeeCurriculamActivitieInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeCurriculamActivitieInfo employeeCurriculamActivitieInfo = db.EmployeeCurriculamActivitieInfoes.Find(id);
            if (employeeCurriculamActivitieInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeCurriculamActivitieInfo);
        }

        // GET: Employee/EmployeeCurriculamActivitieInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeCurriculamActivitieInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeCurriculamActivitieInfoId,EmployeeInfoId,Description")] EmployeeCurriculamActivitieInfo employeeCurriculamActivitieInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeCurriculamActivitieInfoes.Add(employeeCurriculamActivitieInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeCurriculamActivitieInfo.EmployeeInfoId);
            return View(employeeCurriculamActivitieInfo);
        }

        // GET: Employee/EmployeeCurriculamActivitieInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeCurriculamActivitieInfo employeeCurriculamActivitieInfo = db.EmployeeCurriculamActivitieInfoes.Find(id);
            if (employeeCurriculamActivitieInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeCurriculamActivitieInfo.EmployeeInfoId);
            return View(employeeCurriculamActivitieInfo);
        }

        // POST: Employee/EmployeeCurriculamActivitieInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeCurriculamActivitieInfoId,EmployeeInfoId,Description")] EmployeeCurriculamActivitieInfo employeeCurriculamActivitieInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeCurriculamActivitieInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeCurriculamActivitieInfo.EmployeeInfoId);
            return View(employeeCurriculamActivitieInfo);
        }

        // GET: Employee/EmployeeCurriculamActivitieInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeCurriculamActivitieInfo employeeCurriculamActivitieInfo = db.EmployeeCurriculamActivitieInfoes.Find(id);
            if (employeeCurriculamActivitieInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeCurriculamActivitieInfo);
        }

        // POST: Employee/EmployeeCurriculamActivitieInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeCurriculamActivitieInfo employeeCurriculamActivitieInfo = db.EmployeeCurriculamActivitieInfoes.Find(id);
            db.EmployeeCurriculamActivitieInfoes.Remove(employeeCurriculamActivitieInfo);
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
