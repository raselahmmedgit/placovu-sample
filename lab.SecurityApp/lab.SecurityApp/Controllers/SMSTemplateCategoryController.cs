using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab.SecurityApp.Models;

namespace lab.SecurityApp.Controllers
{
    public class SMSTemplateCategoryController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: SMSTemplateCategory
        public ActionResult Index()
        {
            return View(db.SMSTemplateCategories.ToList());
        }

        // GET: SMSTemplateCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMSTemplateCategory sMSTemplateCategory = db.SMSTemplateCategories.Find(id);
            if (sMSTemplateCategory == null)
            {
                return HttpNotFound();
            }
            return View(sMSTemplateCategory);
        }

        // GET: SMSTemplateCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMSTemplateCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SMSTemplateCategoryId,Name")] SMSTemplateCategory sMSTemplateCategory)
        {
            if (ModelState.IsValid)
            {
                db.SMSTemplateCategories.Add(sMSTemplateCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sMSTemplateCategory);
        }

        // GET: SMSTemplateCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMSTemplateCategory sMSTemplateCategory = db.SMSTemplateCategories.Find(id);
            if (sMSTemplateCategory == null)
            {
                return HttpNotFound();
            }
            return View(sMSTemplateCategory);
        }

        // POST: SMSTemplateCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SMSTemplateCategoryId,Name")] SMSTemplateCategory sMSTemplateCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMSTemplateCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMSTemplateCategory);
        }

        // GET: SMSTemplateCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMSTemplateCategory sMSTemplateCategory = db.SMSTemplateCategories.Find(id);
            if (sMSTemplateCategory == null)
            {
                return HttpNotFound();
            }
            return View(sMSTemplateCategory);
        }

        // POST: SMSTemplateCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMSTemplateCategory sMSTemplateCategory = db.SMSTemplateCategories.Find(id);
            db.SMSTemplateCategories.Remove(sMSTemplateCategory);
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
