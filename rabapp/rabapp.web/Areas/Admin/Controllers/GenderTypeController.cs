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
    public class GenderTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/GenderType
        public ActionResult Index()
        {
            return View(db.GenderTypes.ToList());
        }

        // GET: Admin/GenderType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderType genderType = db.GenderTypes.Find(id);
            if (genderType == null)
            {
                return HttpNotFound();
            }
            return View(genderType);
        }

        // GET: Admin/GenderType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GenderType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenderTypeId,GenderTypeName")] GenderType genderType)
        {
            if (ModelState.IsValid)
            {
                db.GenderTypes.Add(genderType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genderType);
        }

        // GET: Admin/GenderType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderType genderType = db.GenderTypes.Find(id);
            if (genderType == null)
            {
                return HttpNotFound();
            }
            return View(genderType);
        }

        // POST: Admin/GenderType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenderTypeId,GenderTypeName")] GenderType genderType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genderType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genderType);
        }

        // GET: Admin/GenderType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderType genderType = db.GenderTypes.Find(id);
            if (genderType == null)
            {
                return HttpNotFound();
            }
            return View(genderType);
        }

        // POST: Admin/GenderType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenderType genderType = db.GenderTypes.Find(id);
            db.GenderTypes.Remove(genderType);
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
