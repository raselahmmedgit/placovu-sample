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
    public class LeaveTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/LeaveType
        public ActionResult Index()
        {
            var leaveTypes = db.LeaveTypes.Include(l => l.GenderType);
            return View(leaveTypes.ToList());
        }

        // GET: Admin/LeaveType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveType leaveType = db.LeaveTypes.Find(id);
            if (leaveType == null)
            {
                return HttpNotFound();
            }
            return View(leaveType);
        }

        // GET: Admin/LeaveType/Create
        public ActionResult Create()
        {
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName");
            return View();
        }

        // POST: Admin/LeaveType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeaveTypeId,LeaveTypeName,LeaveDays,GenderTypeId,LeaveCountWorkDayForOneDayLeave")] LeaveType leaveType)
        {
            if (ModelState.IsValid)
            {
                db.LeaveTypes.Add(leaveType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName", leaveType.GenderTypeId);
            return View(leaveType);
        }

        // GET: Admin/LeaveType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveType leaveType = db.LeaveTypes.Find(id);
            if (leaveType == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName", leaveType.GenderTypeId);
            return View(leaveType);
        }

        // POST: Admin/LeaveType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeaveTypeId,LeaveTypeName,LeaveDays,GenderTypeId,LeaveCountWorkDayForOneDayLeave")] LeaveType leaveType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName", leaveType.GenderTypeId);
            return View(leaveType);
        }

        // GET: Admin/LeaveType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveType leaveType = db.LeaveTypes.Find(id);
            if (leaveType == null)
            {
                return HttpNotFound();
            }
            return View(leaveType);
        }

        // POST: Admin/LeaveType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveType leaveType = db.LeaveTypes.Find(id);
            db.LeaveTypes.Remove(leaveType);
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
