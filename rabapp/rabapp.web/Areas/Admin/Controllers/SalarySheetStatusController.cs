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
    public class SalarySheetStatusController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/SalarySheetStatus
        public ActionResult Index()
        {
            return View(db.SalarySheetStatus.ToList());
        }

        // GET: Admin/SalarySheetStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalarySheetStatus salarySheetStatus = db.SalarySheetStatus.Find(id);
            if (salarySheetStatus == null)
            {
                return HttpNotFound();
            }
            return View(salarySheetStatus);
        }

        // GET: Admin/SalarySheetStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SalarySheetStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalarySheetStatusId,SalarySheetStatusName")] SalarySheetStatus salarySheetStatus)
        {
            if (ModelState.IsValid)
            {
                db.SalarySheetStatus.Add(salarySheetStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salarySheetStatus);
        }

        // GET: Admin/SalarySheetStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalarySheetStatus salarySheetStatus = db.SalarySheetStatus.Find(id);
            if (salarySheetStatus == null)
            {
                return HttpNotFound();
            }
            return View(salarySheetStatus);
        }

        // POST: Admin/SalarySheetStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalarySheetStatusId,SalarySheetStatusName")] SalarySheetStatus salarySheetStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salarySheetStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salarySheetStatus);
        }

        // GET: Admin/SalarySheetStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalarySheetStatus salarySheetStatus = db.SalarySheetStatus.Find(id);
            if (salarySheetStatus == null)
            {
                return HttpNotFound();
            }
            return View(salarySheetStatus);
        }

        // POST: Admin/SalarySheetStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalarySheetStatus salarySheetStatus = db.SalarySheetStatus.Find(id);
            db.SalarySheetStatus.Remove(salarySheetStatus);
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
