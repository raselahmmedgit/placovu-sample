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
    public class FreedomFighterRelationshipTypeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/FreedomFighterRelationshipType
        public ActionResult Index()
        {
            return View(db.FreedomFighterRelationshipTypes.ToList());
        }

        // GET: Admin/FreedomFighterRelationshipType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreedomFighterRelationshipType freedomFighterRelationshipType = db.FreedomFighterRelationshipTypes.Find(id);
            if (freedomFighterRelationshipType == null)
            {
                return HttpNotFound();
            }
            return View(freedomFighterRelationshipType);
        }

        // GET: Admin/FreedomFighterRelationshipType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FreedomFighterRelationshipType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FreedomFighterRelationshipTypeId,FreedomFighterRelationshipTypeName")] FreedomFighterRelationshipType freedomFighterRelationshipType)
        {
            if (ModelState.IsValid)
            {
                db.FreedomFighterRelationshipTypes.Add(freedomFighterRelationshipType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(freedomFighterRelationshipType);
        }

        // GET: Admin/FreedomFighterRelationshipType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreedomFighterRelationshipType freedomFighterRelationshipType = db.FreedomFighterRelationshipTypes.Find(id);
            if (freedomFighterRelationshipType == null)
            {
                return HttpNotFound();
            }
            return View(freedomFighterRelationshipType);
        }

        // POST: Admin/FreedomFighterRelationshipType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FreedomFighterRelationshipTypeId,FreedomFighterRelationshipTypeName")] FreedomFighterRelationshipType freedomFighterRelationshipType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freedomFighterRelationshipType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(freedomFighterRelationshipType);
        }

        // GET: Admin/FreedomFighterRelationshipType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreedomFighterRelationshipType freedomFighterRelationshipType = db.FreedomFighterRelationshipTypes.Find(id);
            if (freedomFighterRelationshipType == null)
            {
                return HttpNotFound();
            }
            return View(freedomFighterRelationshipType);
        }

        // POST: Admin/FreedomFighterRelationshipType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FreedomFighterRelationshipType freedomFighterRelationshipType = db.FreedomFighterRelationshipTypes.Find(id);
            db.FreedomFighterRelationshipTypes.Remove(freedomFighterRelationshipType);
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
