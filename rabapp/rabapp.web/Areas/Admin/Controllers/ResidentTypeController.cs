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
    public class ResidentTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/ResidentType
        public ActionResult Index()
        {
            return View(db.ResidentTypes.ToList());
        }

        // GET: Admin/ResidentType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentType residentType = db.ResidentTypes.Find(id);
            if (residentType == null)
            {
                return HttpNotFound();
            }
            return View(residentType);
        }

        // GET: Admin/ResidentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ResidentType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResidentTypeId,ResidentTypeName")] ResidentType residentType)
        {
            if (ModelState.IsValid)
            {
                db.ResidentTypes.Add(residentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(residentType);
        }

        // GET: Admin/ResidentType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentType residentType = db.ResidentTypes.Find(id);
            if (residentType == null)
            {
                return HttpNotFound();
            }
            return View(residentType);
        }

        // POST: Admin/ResidentType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResidentTypeId,ResidentTypeName")] ResidentType residentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(residentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(residentType);
        }

        // GET: Admin/ResidentType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentType residentType = db.ResidentTypes.Find(id);
            if (residentType == null)
            {
                return HttpNotFound();
            }
            return View(residentType);
        }

        // POST: Admin/ResidentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResidentType residentType = db.ResidentTypes.Find(id);
            db.ResidentTypes.Remove(residentType);
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
