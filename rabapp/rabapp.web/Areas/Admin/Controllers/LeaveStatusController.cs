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
    public class LeaveStatusController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/LeaveStatus
        public ActionResult Index()
        {
            return View(db.LeaveStatus.ToList());
        }

        // GET: Admin/LeaveStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveStatus leaveStatus = db.LeaveStatus.Find(id);
            if (leaveStatus == null)
            {
                return HttpNotFound();
            }
            return View(leaveStatus);
        }

        // GET: Admin/LeaveStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LeaveStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeaveStatusId,LeaveStatusName")] LeaveStatus leaveStatus)
        {
            if (ModelState.IsValid)
            {
                db.LeaveStatus.Add(leaveStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leaveStatus);
        }

        // GET: Admin/LeaveStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveStatus leaveStatus = db.LeaveStatus.Find(id);
            if (leaveStatus == null)
            {
                return HttpNotFound();
            }
            return View(leaveStatus);
        }

        // POST: Admin/LeaveStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeaveStatusId,LeaveStatusName")] LeaveStatus leaveStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leaveStatus);
        }

        // GET: Admin/LeaveStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveStatus leaveStatus = db.LeaveStatus.Find(id);
            if (leaveStatus == null)
            {
                return HttpNotFound();
            }
            return View(leaveStatus);
        }

        // POST: Admin/LeaveStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveStatus leaveStatus = db.LeaveStatus.Find(id);
            db.LeaveStatus.Remove(leaveStatus);
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
