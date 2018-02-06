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
    public class FreedomFighterTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/FreedomFighterType
        public ActionResult Index()
        {
            return View(db.FreedomFighterTypes.ToList());
        }

        // GET: Admin/FreedomFighterType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreedomFighterType freedomFighterType = db.FreedomFighterTypes.Find(id);
            if (freedomFighterType == null)
            {
                return HttpNotFound();
            }
            return View(freedomFighterType);
        }

        // GET: Admin/FreedomFighterType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FreedomFighterType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FreedomFighterTypeId,FreedomFighterTypeName")] FreedomFighterType freedomFighterType)
        {
            if (ModelState.IsValid)
            {
                db.FreedomFighterTypes.Add(freedomFighterType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(freedomFighterType);
        }

        // GET: Admin/FreedomFighterType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreedomFighterType freedomFighterType = db.FreedomFighterTypes.Find(id);
            if (freedomFighterType == null)
            {
                return HttpNotFound();
            }
            return View(freedomFighterType);
        }

        // POST: Admin/FreedomFighterType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FreedomFighterTypeId,FreedomFighterTypeName")] FreedomFighterType freedomFighterType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freedomFighterType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(freedomFighterType);
        }

        // GET: Admin/FreedomFighterType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreedomFighterType freedomFighterType = db.FreedomFighterTypes.Find(id);
            if (freedomFighterType == null)
            {
                return HttpNotFound();
            }
            return View(freedomFighterType);
        }

        // POST: Admin/FreedomFighterType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FreedomFighterType freedomFighterType = db.FreedomFighterTypes.Find(id);
            db.FreedomFighterTypes.Remove(freedomFighterType);
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
