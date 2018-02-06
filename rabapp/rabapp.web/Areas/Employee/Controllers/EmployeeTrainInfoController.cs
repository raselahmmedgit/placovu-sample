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
    public class EmployeeTrainInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeTrainInfo
        public ActionResult Index()
        {
            var employeeTrainInfoes = db.EmployeeTrainInfoes.Include(e => e.EmployeeInfo);
            return View(employeeTrainInfoes.ToList());
        }

        // GET: Employee/EmployeeTrainInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTrainInfo employeeTrainInfo = db.EmployeeTrainInfoes.Find(id);
            if (employeeTrainInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeTrainInfo);
        }

        // GET: Employee/EmployeeTrainInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeTrainInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeTrainInfoId,EmployeeInfoId,TrainingTitle,TopicsCovered,InstituteName,TrainingLocation,TrainingDuration")] EmployeeTrainInfo employeeTrainInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTrainInfoes.Add(employeeTrainInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeTrainInfo.EmployeeInfoId);
            return View(employeeTrainInfo);
        }

        // GET: Employee/EmployeeTrainInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTrainInfo employeeTrainInfo = db.EmployeeTrainInfoes.Find(id);
            if (employeeTrainInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeTrainInfo.EmployeeInfoId);
            return View(employeeTrainInfo);
        }

        // POST: Employee/EmployeeTrainInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeTrainInfoId,EmployeeInfoId,TrainingTitle,TopicsCovered,InstituteName,TrainingLocation,TrainingDuration")] EmployeeTrainInfo employeeTrainInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTrainInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeTrainInfo.EmployeeInfoId);
            return View(employeeTrainInfo);
        }

        // GET: Employee/EmployeeTrainInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTrainInfo employeeTrainInfo = db.EmployeeTrainInfoes.Find(id);
            if (employeeTrainInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeTrainInfo);
        }

        // POST: Employee/EmployeeTrainInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeTrainInfo employeeTrainInfo = db.EmployeeTrainInfoes.Find(id);
            db.EmployeeTrainInfoes.Remove(employeeTrainInfo);
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
