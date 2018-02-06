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
    public class EmployeeForeignTravelInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeForeignTravelInfo
        public ActionResult Index()
        {
            var employeeForeignTravelInfoes = db.EmployeeForeignTravelInfoes.Include(e => e.Country).Include(e => e.EmployeeInfo);
            return View(employeeForeignTravelInfoes.ToList());
        }

        // GET: Employee/EmployeeForeignTravelInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeForeignTravelInfo employeeForeignTravelInfo = db.EmployeeForeignTravelInfoes.Find(id);
            if (employeeForeignTravelInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeForeignTravelInfo);
        }

        // GET: Employee/EmployeeForeignTravelInfo/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeForeignTravelInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeForeignTravelInfoId,EmployeeInfoId,ForeignTravelTitle,InstituteTitle,GradePosition,CountryId,FromDate,ToDate")] EmployeeForeignTravelInfo employeeForeignTravelInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeForeignTravelInfoes.Add(employeeForeignTravelInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", employeeForeignTravelInfo.CountryId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeForeignTravelInfo.EmployeeInfoId);
            return View(employeeForeignTravelInfo);
        }

        // GET: Employee/EmployeeForeignTravelInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeForeignTravelInfo employeeForeignTravelInfo = db.EmployeeForeignTravelInfoes.Find(id);
            if (employeeForeignTravelInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", employeeForeignTravelInfo.CountryId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeForeignTravelInfo.EmployeeInfoId);
            return View(employeeForeignTravelInfo);
        }

        // POST: Employee/EmployeeForeignTravelInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeForeignTravelInfoId,EmployeeInfoId,ForeignTravelTitle,InstituteTitle,GradePosition,CountryId,FromDate,ToDate")] EmployeeForeignTravelInfo employeeForeignTravelInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeForeignTravelInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", employeeForeignTravelInfo.CountryId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeForeignTravelInfo.EmployeeInfoId);
            return View(employeeForeignTravelInfo);
        }

        // GET: Employee/EmployeeForeignTravelInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeForeignTravelInfo employeeForeignTravelInfo = db.EmployeeForeignTravelInfoes.Find(id);
            if (employeeForeignTravelInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeForeignTravelInfo);
        }

        // POST: Employee/EmployeeForeignTravelInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeForeignTravelInfo employeeForeignTravelInfo = db.EmployeeForeignTravelInfoes.Find(id);
            db.EmployeeForeignTravelInfoes.Remove(employeeForeignTravelInfo);
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
