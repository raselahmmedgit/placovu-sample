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

namespace rabapp.web.Areas.Leave.Controllers
{
    public class LeaveApplicationController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Leave/LeaveApplication
        public ActionResult Index()
        {
            var leaveApplications = db.LeaveApplications.Include(l => l.AttachmentFile).Include(l => l.EmployeeInfo).Include(l => l.LeaveType);
            return View(leaveApplications.ToList());
        }

        // GET: Leave/LeaveApplication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplication leaveApplication = db.LeaveApplications.Find(id);
            if (leaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplication);
        }

        // GET: Leave/LeaveApplication/Create
        public ActionResult Create()
        {
            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType");
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "LeaveTypeId", "LeaveTypeName");
            return View();
        }

        // POST: Leave/LeaveApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeaveApplicationId,EmployeeInfoId,LeaveTypeId,StartDate,EndDate,DurationDate,LeaveReason,AttachmentFileId")] LeaveApplication leaveApplication)
        {
            if (ModelState.IsValid)
            {
                db.LeaveApplications.Add(leaveApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", leaveApplication.AttachmentFileId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", leaveApplication.EmployeeInfoId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "LeaveTypeId", "LeaveTypeName", leaveApplication.LeaveTypeId);
            return View(leaveApplication);
        }

        // GET: Leave/LeaveApplication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplication leaveApplication = db.LeaveApplications.Find(id);
            if (leaveApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", leaveApplication.AttachmentFileId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", leaveApplication.EmployeeInfoId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "LeaveTypeId", "LeaveTypeName", leaveApplication.LeaveTypeId);
            return View(leaveApplication);
        }

        // POST: Leave/LeaveApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeaveApplicationId,EmployeeInfoId,LeaveTypeId,StartDate,EndDate,DurationDate,LeaveReason,AttachmentFileId")] LeaveApplication leaveApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttachmentFileId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", leaveApplication.AttachmentFileId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", leaveApplication.EmployeeInfoId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "LeaveTypeId", "LeaveTypeName", leaveApplication.LeaveTypeId);
            return View(leaveApplication);
        }

        // GET: Leave/LeaveApplication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplication leaveApplication = db.LeaveApplications.Find(id);
            if (leaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplication);
        }

        // POST: Leave/LeaveApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveApplication leaveApplication = db.LeaveApplications.Find(id);
            db.LeaveApplications.Remove(leaveApplication);
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
