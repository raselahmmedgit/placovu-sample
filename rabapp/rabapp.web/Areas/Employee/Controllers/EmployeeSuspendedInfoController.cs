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
    public class EmployeeSuspendedInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeSuspendedInfo
        public ActionResult Index()
        {
            var employeeSuspendedInfoes = db.EmployeeSuspendedInfoes.Include(e => e.AttachmentFile).Include(e => e.EmployeeInfo);
            return View(employeeSuspendedInfoes.ToList());
        }

        // GET: Employee/EmployeeSuspendedInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSuspendedInfo employeeSuspendedInfo = db.EmployeeSuspendedInfoes.Find(id);
            if (employeeSuspendedInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeSuspendedInfo);
        }

        // GET: Employee/EmployeeSuspendedInfo/Create
        public ActionResult Create()
        {
            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType");
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeSuspendedInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeSuspendedInfoId,EmployeeInfoId,Description,AttachmentFileId,ActionProsecutionDate,IssueDate,FromDate,ToDate,DurationDate")] EmployeeSuspendedInfo employeeSuspendedInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeSuspendedInfoes.Add(employeeSuspendedInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeSuspendedInfo.AttachmentFileId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeSuspendedInfo.EmployeeInfoId);
            return View(employeeSuspendedInfo);
        }

        // GET: Employee/EmployeeSuspendedInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSuspendedInfo employeeSuspendedInfo = db.EmployeeSuspendedInfoes.Find(id);
            if (employeeSuspendedInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeSuspendedInfo.AttachmentFileId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeSuspendedInfo.EmployeeInfoId);
            return View(employeeSuspendedInfo);
        }

        // POST: Employee/EmployeeSuspendedInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeSuspendedInfoId,EmployeeInfoId,Description,AttachmentFileId,ActionProsecutionDate,IssueDate,FromDate,ToDate,DurationDate")] EmployeeSuspendedInfo employeeSuspendedInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeSuspendedInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeSuspendedInfo.AttachmentFileId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeSuspendedInfo.EmployeeInfoId);
            return View(employeeSuspendedInfo);
        }

        // GET: Employee/EmployeeSuspendedInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSuspendedInfo employeeSuspendedInfo = db.EmployeeSuspendedInfoes.Find(id);
            if (employeeSuspendedInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeSuspendedInfo);
        }

        // POST: Employee/EmployeeSuspendedInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeSuspendedInfo employeeSuspendedInfo = db.EmployeeSuspendedInfoes.Find(id);
            db.EmployeeSuspendedInfoes.Remove(employeeSuspendedInfo);
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
