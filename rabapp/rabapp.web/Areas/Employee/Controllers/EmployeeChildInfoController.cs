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
    public class EmployeeChildInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeChildInfo
        public ActionResult Index()
        {
            var employeeChildInfoes = db.EmployeeChildInfoes.Include(e => e.EmployeeInfo).Include(e => e.GenderType);
            return View(employeeChildInfoes.ToList());
        }

        // GET: Employee/EmployeeChildInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeChildInfo employeeChildInfo = db.EmployeeChildInfoes.Find(id);
            if (employeeChildInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeChildInfo);
        }

        // GET: Employee/EmployeeChildInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName");
            return View();
        }

        // POST: Employee/EmployeeChildInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeChildInfoId,EmployeeInfoId,EmployeeChildName,ChildAge,DateOfBirth,GenderTypeId")] EmployeeChildInfo employeeChildInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeChildInfoes.Add(employeeChildInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeChildInfo.EmployeeInfoId);
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName", employeeChildInfo.GenderTypeId);
            return View(employeeChildInfo);
        }

        // GET: Employee/EmployeeChildInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeChildInfo employeeChildInfo = db.EmployeeChildInfoes.Find(id);
            if (employeeChildInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeChildInfo.EmployeeInfoId);
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName", employeeChildInfo.GenderTypeId);
            return View(employeeChildInfo);
        }

        // POST: Employee/EmployeeChildInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeChildInfoId,EmployeeInfoId,EmployeeChildName,ChildAge,DateOfBirth,GenderTypeId")] EmployeeChildInfo employeeChildInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeChildInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeChildInfo.EmployeeInfoId);
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName", employeeChildInfo.GenderTypeId);
            return View(employeeChildInfo);
        }

        // GET: Employee/EmployeeChildInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeChildInfo employeeChildInfo = db.EmployeeChildInfoes.Find(id);
            if (employeeChildInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeChildInfo);
        }

        // POST: Employee/EmployeeChildInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeChildInfo employeeChildInfo = db.EmployeeChildInfoes.Find(id);
            db.EmployeeChildInfoes.Remove(employeeChildInfo);
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
