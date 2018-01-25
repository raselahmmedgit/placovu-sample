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
    public class LeaveStepController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/LeaveStep
        public ActionResult Index()
        {
            var leaveSteps = db.LeaveSteps.Include(l => l.Branch).Include(l => l.LeaveType).Include(l => l.Role);
            return View(leaveSteps.ToList());
        }

        // GET: Admin/LeaveStep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveStep leaveStep = db.LeaveSteps.Find(id);
            if (leaveStep == null)
            {
                return HttpNotFound();
            }
            return View(leaveStep);
        }

        // GET: Admin/LeaveStep/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName");
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "LeaveTypeId", "LeaveTypeName");
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: Admin/LeaveStep/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeaveStepId,LeaveStepName,BranchId,LeaveTypeId,LeaveStepOrder,RoleId")] LeaveStep leaveStep)
        {
            if (ModelState.IsValid)
            {
                db.LeaveSteps.Add(leaveStep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", leaveStep.BranchId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "LeaveTypeId", "LeaveTypeName", leaveStep.LeaveTypeId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", leaveStep.RoleId);
            return View(leaveStep);
        }

        // GET: Admin/LeaveStep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveStep leaveStep = db.LeaveSteps.Find(id);
            if (leaveStep == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", leaveStep.BranchId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "LeaveTypeId", "LeaveTypeName", leaveStep.LeaveTypeId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", leaveStep.RoleId);
            return View(leaveStep);
        }

        // POST: Admin/LeaveStep/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeaveStepId,LeaveStepName,BranchId,LeaveTypeId,LeaveStepOrder,RoleId")] LeaveStep leaveStep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveStep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", leaveStep.BranchId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "LeaveTypeId", "LeaveTypeName", leaveStep.LeaveTypeId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", leaveStep.RoleId);
            return View(leaveStep);
        }

        // GET: Admin/LeaveStep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveStep leaveStep = db.LeaveSteps.Find(id);
            if (leaveStep == null)
            {
                return HttpNotFound();
            }
            return View(leaveStep);
        }

        // POST: Admin/LeaveStep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveStep leaveStep = db.LeaveSteps.Find(id);
            db.LeaveSteps.Remove(leaveStep);
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
