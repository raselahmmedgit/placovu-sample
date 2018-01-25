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
    public class SalaryGradeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/SalaryGrade
        public ActionResult Index()
        {
            return View(db.SalaryGrades.ToList());
        }

        // GET: Admin/SalaryGrade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryGrade salaryGrade = db.SalaryGrades.Find(id);
            if (salaryGrade == null)
            {
                return HttpNotFound();
            }
            return View(salaryGrade);
        }

        // GET: Admin/SalaryGrade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SalaryGrade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalaryGradeId,SalaryGradeName")] SalaryGrade salaryGrade)
        {
            if (ModelState.IsValid)
            {
                db.SalaryGrades.Add(salaryGrade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salaryGrade);
        }

        // GET: Admin/SalaryGrade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryGrade salaryGrade = db.SalaryGrades.Find(id);
            if (salaryGrade == null)
            {
                return HttpNotFound();
            }
            return View(salaryGrade);
        }

        // POST: Admin/SalaryGrade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalaryGradeId,SalaryGradeName")] SalaryGrade salaryGrade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryGrade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salaryGrade);
        }

        // GET: Admin/SalaryGrade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryGrade salaryGrade = db.SalaryGrades.Find(id);
            if (salaryGrade == null)
            {
                return HttpNotFound();
            }
            return View(salaryGrade);
        }

        // POST: Admin/SalaryGrade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryGrade salaryGrade = db.SalaryGrades.Find(id);
            db.SalaryGrades.Remove(salaryGrade);
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
