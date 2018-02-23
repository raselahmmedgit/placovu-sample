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
    public class SalaryHeadTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/SalaryHeadType
        public ActionResult Index()
        {
            return View(db.SalaryHeadTypes.ToList());
        }

        // GET: Admin/SalaryHeadType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHeadType salaryHeadType = db.SalaryHeadTypes.Find(id);
            if (salaryHeadType == null)
            {
                return HttpNotFound();
            }
            return View(salaryHeadType);
        }

        // GET: Admin/SalaryHeadType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SalaryHeadType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalaryHeadTypeId,SalaryHeadTypeName")] SalaryHeadType salaryHeadType)
        {
            if (ModelState.IsValid)
            {
                db.SalaryHeadTypes.Add(salaryHeadType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salaryHeadType);
        }

        // GET: Admin/SalaryHeadType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHeadType salaryHeadType = db.SalaryHeadTypes.Find(id);
            if (salaryHeadType == null)
            {
                return HttpNotFound();
            }
            return View(salaryHeadType);
        }

        // POST: Admin/SalaryHeadType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalaryHeadTypeId,SalaryHeadTypeName")] SalaryHeadType salaryHeadType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryHeadType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salaryHeadType);
        }

        // GET: Admin/SalaryHeadType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHeadType salaryHeadType = db.SalaryHeadTypes.Find(id);
            if (salaryHeadType == null)
            {
                return HttpNotFound();
            }
            return View(salaryHeadType);
        }

        // POST: Admin/SalaryHeadType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryHeadType salaryHeadType = db.SalaryHeadTypes.Find(id);
            db.SalaryHeadTypes.Remove(salaryHeadType);
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
