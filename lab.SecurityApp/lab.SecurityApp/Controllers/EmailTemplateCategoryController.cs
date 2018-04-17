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
    public class EmailTemplateCategoryController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: EmailTemplateCategory
        public ActionResult Index()
        {
            return View(db.EmailTemplateCategories.ToList());
        }

        // GET: EmailTemplateCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplateCategory emailTemplateCategory = db.EmailTemplateCategories.Find(id);
            if (emailTemplateCategory == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplateCategory);
        }

        // GET: EmailTemplateCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailTemplateCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailTemplateCategoryId,Name")] EmailTemplateCategory emailTemplateCategory)
        {
            if (ModelState.IsValid)
            {
                db.EmailTemplateCategories.Add(emailTemplateCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emailTemplateCategory);
        }

        // GET: EmailTemplateCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplateCategory emailTemplateCategory = db.EmailTemplateCategories.Find(id);
            if (emailTemplateCategory == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplateCategory);
        }

        // POST: EmailTemplateCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailTemplateCategoryId,Name")] EmailTemplateCategory emailTemplateCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailTemplateCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailTemplateCategory);
        }

        // GET: EmailTemplateCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplateCategory emailTemplateCategory = db.EmailTemplateCategories.Find(id);
            if (emailTemplateCategory == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplateCategory);
        }

        // POST: EmailTemplateCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailTemplateCategory emailTemplateCategory = db.EmailTemplateCategories.Find(id);
            db.EmailTemplateCategories.Remove(emailTemplateCategory);
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
