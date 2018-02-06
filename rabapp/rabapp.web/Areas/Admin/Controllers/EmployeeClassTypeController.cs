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
    public class EmployeeClassTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/EmployeeClassType
        public ActionResult Index()
        {
            return View(db.EmployeeClassTypes.ToList());
        }

        // GET: Admin/EmployeeClassType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeClassType employeeClassType = db.EmployeeClassTypes.Find(id);
            if (employeeClassType == null)
            {
                return HttpNotFound();
            }
            return View(employeeClassType);
        }

        // GET: Admin/EmployeeClassType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/EmployeeClassType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeClassTypeId,EmployeeClassTypeName")] EmployeeClassType employeeClassType)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeClassTypes.Add(employeeClassType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeClassType);
        }

        // GET: Admin/EmployeeClassType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeClassType employeeClassType = db.EmployeeClassTypes.Find(id);
            if (employeeClassType == null)
            {
                return HttpNotFound();
            }
            return View(employeeClassType);
        }

        // POST: Admin/EmployeeClassType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeClassTypeId,EmployeeClassTypeName")] EmployeeClassType employeeClassType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeClassType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeClassType);
        }

        // GET: Admin/EmployeeClassType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeClassType employeeClassType = db.EmployeeClassTypes.Find(id);
            if (employeeClassType == null)
            {
                return HttpNotFound();
            }
            return View(employeeClassType);
        }

        // POST: Admin/EmployeeClassType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeClassType employeeClassType = db.EmployeeClassTypes.Find(id);
            db.EmployeeClassTypes.Remove(employeeClassType);
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
