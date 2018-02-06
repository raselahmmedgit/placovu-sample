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
    public class EmployeeDisciplinaryActionCriminalProsecutionInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeDisciplinaryActionCriminalProsecutionInfo
        public ActionResult Index()
        {
            var employeeDisciplinaryActionCriminalProsecutionInfoes = db.EmployeeDisciplinaryActionCriminalProsecutionInfoes.Include(e => e.AttachmentFile).Include(e => e.EmployeeInfo);
            return View(employeeDisciplinaryActionCriminalProsecutionInfoes.ToList());
        }

        // GET: Employee/EmployeeDisciplinaryActionCriminalProsecutionInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDisciplinaryActionCriminalProsecutionInfo employeeDisciplinaryActionCriminalProsecutionInfo = db.EmployeeDisciplinaryActionCriminalProsecutionInfoes.Find(id);
            if (employeeDisciplinaryActionCriminalProsecutionInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeDisciplinaryActionCriminalProsecutionInfo);
        }

        // GET: Employee/EmployeeDisciplinaryActionCriminalProsecutionInfo/Create
        public ActionResult Create()
        {
            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType");
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeDisciplinaryActionCriminalProsecutionInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeDisciplinaryActionCriminalProsecutionInfoId,EmployeeInfoId,Description,AttachmentFileId,ActionProsecutionDate")] EmployeeDisciplinaryActionCriminalProsecutionInfo employeeDisciplinaryActionCriminalProsecutionInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeDisciplinaryActionCriminalProsecutionInfoes.Add(employeeDisciplinaryActionCriminalProsecutionInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeDisciplinaryActionCriminalProsecutionInfo.AttachmentFileId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeDisciplinaryActionCriminalProsecutionInfo.EmployeeInfoId);
            return View(employeeDisciplinaryActionCriminalProsecutionInfo);
        }

        // GET: Employee/EmployeeDisciplinaryActionCriminalProsecutionInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDisciplinaryActionCriminalProsecutionInfo employeeDisciplinaryActionCriminalProsecutionInfo = db.EmployeeDisciplinaryActionCriminalProsecutionInfoes.Find(id);
            if (employeeDisciplinaryActionCriminalProsecutionInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeDisciplinaryActionCriminalProsecutionInfo.AttachmentFileId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeDisciplinaryActionCriminalProsecutionInfo.EmployeeInfoId);
            return View(employeeDisciplinaryActionCriminalProsecutionInfo);
        }

        // POST: Employee/EmployeeDisciplinaryActionCriminalProsecutionInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeDisciplinaryActionCriminalProsecutionInfoId,EmployeeInfoId,Description,AttachmentFileId,ActionProsecutionDate")] EmployeeDisciplinaryActionCriminalProsecutionInfo employeeDisciplinaryActionCriminalProsecutionInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDisciplinaryActionCriminalProsecutionInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeDisciplinaryActionCriminalProsecutionInfo.AttachmentFileId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeDisciplinaryActionCriminalProsecutionInfo.EmployeeInfoId);
            return View(employeeDisciplinaryActionCriminalProsecutionInfo);
        }

        // GET: Employee/EmployeeDisciplinaryActionCriminalProsecutionInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDisciplinaryActionCriminalProsecutionInfo employeeDisciplinaryActionCriminalProsecutionInfo = db.EmployeeDisciplinaryActionCriminalProsecutionInfoes.Find(id);
            if (employeeDisciplinaryActionCriminalProsecutionInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeDisciplinaryActionCriminalProsecutionInfo);
        }

        // POST: Employee/EmployeeDisciplinaryActionCriminalProsecutionInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDisciplinaryActionCriminalProsecutionInfo employeeDisciplinaryActionCriminalProsecutionInfo = db.EmployeeDisciplinaryActionCriminalProsecutionInfoes.Find(id);
            db.EmployeeDisciplinaryActionCriminalProsecutionInfoes.Remove(employeeDisciplinaryActionCriminalProsecutionInfo);
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
