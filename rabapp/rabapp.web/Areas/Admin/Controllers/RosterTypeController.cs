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
    public class RosterTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/RosterType
        public ActionResult Index()
        {
            return View(db.RosterTypes.ToList());
        }

        // GET: Admin/RosterType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RosterType rosterType = db.RosterTypes.Find(id);
            if (rosterType == null)
            {
                return HttpNotFound();
            }
            return View(rosterType);
        }

        // GET: Admin/RosterType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RosterType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RosterTypeId,RosterTypeName")] RosterType rosterType)
        {
            if (ModelState.IsValid)
            {
                db.RosterTypes.Add(rosterType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rosterType);
        }

        // GET: Admin/RosterType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RosterType rosterType = db.RosterTypes.Find(id);
            if (rosterType == null)
            {
                return HttpNotFound();
            }
            return View(rosterType);
        }

        // POST: Admin/RosterType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RosterTypeId,RosterTypeName")] RosterType rosterType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rosterType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rosterType);
        }

        // GET: Admin/RosterType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RosterType rosterType = db.RosterTypes.Find(id);
            if (rosterType == null)
            {
                return HttpNotFound();
            }
            return View(rosterType);
        }

        // POST: Admin/RosterType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RosterType rosterType = db.RosterTypes.Find(id);
            db.RosterTypes.Remove(rosterType);
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
