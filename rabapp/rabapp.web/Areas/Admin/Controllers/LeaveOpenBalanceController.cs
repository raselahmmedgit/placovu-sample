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
    public class LeaveOpenBalanceController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/LeaveOpenBalance
        public ActionResult Index()
        {
            return View(db.LeaveOpenBalances.ToList());
        }

        // GET: Admin/LeaveOpenBalance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveOpenBalance leaveOpenBalance = db.LeaveOpenBalances.Find(id);
            if (leaveOpenBalance == null)
            {
                return HttpNotFound();
            }
            return View(leaveOpenBalance);
        }

        // GET: Admin/LeaveOpenBalance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LeaveOpenBalance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeaveOpenBalanceId,LeaveOpenBalanceName,LeaveTotal,LeavePaid,LeaveBalance")] LeaveOpenBalance leaveOpenBalance)
        {
            if (ModelState.IsValid)
            {
                db.LeaveOpenBalances.Add(leaveOpenBalance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leaveOpenBalance);
        }

        // GET: Admin/LeaveOpenBalance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveOpenBalance leaveOpenBalance = db.LeaveOpenBalances.Find(id);
            if (leaveOpenBalance == null)
            {
                return HttpNotFound();
            }
            return View(leaveOpenBalance);
        }

        // POST: Admin/LeaveOpenBalance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeaveOpenBalanceId,LeaveOpenBalanceName,LeaveTotal,LeavePaid,LeaveBalance")] LeaveOpenBalance leaveOpenBalance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveOpenBalance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leaveOpenBalance);
        }

        // GET: Admin/LeaveOpenBalance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveOpenBalance leaveOpenBalance = db.LeaveOpenBalances.Find(id);
            if (leaveOpenBalance == null)
            {
                return HttpNotFound();
            }
            return View(leaveOpenBalance);
        }

        // POST: Admin/LeaveOpenBalance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveOpenBalance leaveOpenBalance = db.LeaveOpenBalances.Find(id);
            db.LeaveOpenBalances.Remove(leaveOpenBalance);
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
