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
    public class SMSTemplateController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: SMSTemplate
        public ActionResult Index()
        {
            var sMSTemplates = db.SMSTemplates.Include(s => s.SMSTemplateCategory);
            return View(sMSTemplates.ToList());
        }

        // GET: SMSTemplate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMSTemplate sMSTemplate = db.SMSTemplates.Find(id);
            if (sMSTemplate == null)
            {
                return HttpNotFound();
            }
            return View(sMSTemplate);
        }

        // GET: SMSTemplate/Create
        public ActionResult Create()
        {
            ViewBag.SMSTemplateCategoryId = new SelectList(db.SMSTemplateCategories, "SMSTemplateCategoryId", "Name");
            return View();
        }

        // POST: SMSTemplate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SMSTemplateId,Name,SMSSubject,SMSMessage,IsAdmin,IsShared,SMSTemplateCategoryId")] SMSTemplate sMSTemplate)
        {
            if (ModelState.IsValid)
            {
                db.SMSTemplates.Add(sMSTemplate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SMSTemplateCategoryId = new SelectList(db.SMSTemplateCategories, "SMSTemplateCategoryId", "Name", sMSTemplate.SMSTemplateCategoryId);
            return View(sMSTemplate);
        }

        // GET: SMSTemplate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMSTemplate sMSTemplate = db.SMSTemplates.Find(id);
            if (sMSTemplate == null)
            {
                return HttpNotFound();
            }
            ViewBag.SMSTemplateCategoryId = new SelectList(db.SMSTemplateCategories, "SMSTemplateCategoryId", "Name", sMSTemplate.SMSTemplateCategoryId);
            return View(sMSTemplate);
        }

        // POST: SMSTemplate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SMSTemplateId,Name,SMSSubject,SMSMessage,IsAdmin,IsShared,SMSTemplateCategoryId")] SMSTemplate sMSTemplate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMSTemplate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SMSTemplateCategoryId = new SelectList(db.SMSTemplateCategories, "SMSTemplateCategoryId", "Name", sMSTemplate.SMSTemplateCategoryId);
            return View(sMSTemplate);
        }

        // GET: SMSTemplate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMSTemplate sMSTemplate = db.SMSTemplates.Find(id);
            if (sMSTemplate == null)
            {
                return HttpNotFound();
            }
            return View(sMSTemplate);
        }

        // POST: SMSTemplate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMSTemplate sMSTemplate = db.SMSTemplates.Find(id);
            db.SMSTemplates.Remove(sMSTemplate);
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
