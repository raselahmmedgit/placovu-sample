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
    public class EmailTemplateController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: EmailTemplate
        public ActionResult Index()
        {
            var emailTemplates = db.EmailTemplates.Include(e => e.EmailTemplateCategory);
            return View(emailTemplates.ToList());
        }

        // GET: EmailTemplate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplate emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplate);
        }

        // GET: EmailTemplate/Create
        public ActionResult Create()
        {
            ViewBag.EmailTemplateCategoryId = new SelectList(db.EmailTemplateCategories, "EmailTemplateCategoryId", "Name");
            return View();
        }

        // POST: EmailTemplate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailTemplateId,Name,EmailSubject,EmailMessage,IsAdmin,IsShared,EmailTemplateCategoryId")] EmailTemplate emailTemplate)
        {
            if (ModelState.IsValid)
            {
                db.EmailTemplates.Add(emailTemplate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmailTemplateCategoryId = new SelectList(db.EmailTemplateCategories, "EmailTemplateCategoryId", "Name", emailTemplate.EmailTemplateCategoryId);
            return View(emailTemplate);
        }

        // GET: EmailTemplate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplate emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmailTemplateCategoryId = new SelectList(db.EmailTemplateCategories, "EmailTemplateCategoryId", "Name", emailTemplate.EmailTemplateCategoryId);
            return View(emailTemplate);
        }

        // POST: EmailTemplate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailTemplateId,Name,EmailSubject,EmailMessage,IsAdmin,IsShared,EmailTemplateCategoryId")] EmailTemplate emailTemplate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailTemplate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmailTemplateCategoryId = new SelectList(db.EmailTemplateCategories, "EmailTemplateCategoryId", "Name", emailTemplate.EmailTemplateCategoryId);
            return View(emailTemplate);
        }

        // GET: EmailTemplate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplate emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplate);
        }

        // POST: EmailTemplate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailTemplate emailTemplate = db.EmailTemplates.Find(id);
            db.EmailTemplates.Remove(emailTemplate);
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
