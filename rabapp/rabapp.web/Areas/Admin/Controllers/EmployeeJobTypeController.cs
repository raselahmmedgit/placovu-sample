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

namespace rabapp.web.Areas.Admin.Controllers
{
    public class EmployeeJobTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/EmployeeJobType
        public ActionResult Index()
        {
            return View(db.EmployeeJobTypes.ToList());
        }

        // GET: Admin/EmployeeJobType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeJobType employeeJobType = db.EmployeeJobTypes.Find(id);
            if (employeeJobType == null)
            {
                return HttpNotFound();
            }
            return View(employeeJobType);
        }

        // GET: Admin/EmployeeJobType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/EmployeeJobType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeJobTypeId,EmployeeJobTypeName")] EmployeeJobType employeeJobType)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeJobTypes.Add(employeeJobType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeJobType);
        }

        // GET: Admin/EmployeeJobType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeJobType employeeJobType = db.EmployeeJobTypes.Find(id);
            if (employeeJobType == null)
            {
                return HttpNotFound();
            }
            return View(employeeJobType);
        }

        // POST: Admin/EmployeeJobType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeJobTypeId,EmployeeJobTypeName")] EmployeeJobType employeeJobType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeJobType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeJobType);
        }

        // GET: Admin/EmployeeJobType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeJobType employeeJobType = db.EmployeeJobTypes.Find(id);
            if (employeeJobType == null)
            {
                return HttpNotFound();
            }
            return View(employeeJobType);
        }

        // POST: Admin/EmployeeJobType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeJobType employeeJobType = db.EmployeeJobTypes.Find(id);
            db.EmployeeJobTypes.Remove(employeeJobType);
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
