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
    public class LoanStepController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/LoanStep
        public ActionResult Index()
        {
            var loanSteps = db.LoanSteps.Include(l => l.Branch).Include(l => l.LoanType).Include(l => l.Role);
            return View(loanSteps.ToList());
        }

        // GET: Admin/LoanStep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanStep loanStep = db.LoanSteps.Find(id);
            if (loanStep == null)
            {
                return HttpNotFound();
            }
            return View(loanStep);
        }

        // GET: Admin/LoanStep/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName");
            ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "LoanTypeId", "LoanTypeName");
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: Admin/LoanStep/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoanStepId,LoanStepName,BranchId,LoanTypeId,LoanStepOrder,RoleId")] LoanStep loanStep)
        {
            if (ModelState.IsValid)
            {
                db.LoanSteps.Add(loanStep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", loanStep.BranchId);
            ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "LoanTypeId", "LoanTypeName", loanStep.LoanTypeId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", loanStep.RoleId);
            return View(loanStep);
        }

        // GET: Admin/LoanStep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanStep loanStep = db.LoanSteps.Find(id);
            if (loanStep == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", loanStep.BranchId);
            ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "LoanTypeId", "LoanTypeName", loanStep.LoanTypeId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", loanStep.RoleId);
            return View(loanStep);
        }

        // POST: Admin/LoanStep/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanStepId,LoanStepName,BranchId,LoanTypeId,LoanStepOrder,RoleId")] LoanStep loanStep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanStep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "BranchName", loanStep.BranchId);
            ViewBag.LoanTypeId = new SelectList(db.LoanTypes, "LoanTypeId", "LoanTypeName", loanStep.LoanTypeId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", loanStep.RoleId);
            return View(loanStep);
        }

        // GET: Admin/LoanStep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanStep loanStep = db.LoanSteps.Find(id);
            if (loanStep == null)
            {
                return HttpNotFound();
            }
            return View(loanStep);
        }

        // POST: Admin/LoanStep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanStep loanStep = db.LoanSteps.Find(id);
            db.LoanSteps.Remove(loanStep);
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
