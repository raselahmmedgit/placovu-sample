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

namespace rabapp.web.Areas.Employee.Controllers
{
    public class EmployeeResearchPublicationInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeResearchPublicationInfo
        public ActionResult Index()
        {
            var employeeResearchPublicationInfoes = db.EmployeeResearchPublicationInfoes.Include(e => e.BookType).Include(e => e.Country).Include(e => e.EmployeeInfo);
            return View(employeeResearchPublicationInfoes.ToList());
        }

        // GET: Employee/EmployeeResearchPublicationInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeResearchPublicationInfo employeeResearchPublicationInfo = db.EmployeeResearchPublicationInfoes.Find(id);
            if (employeeResearchPublicationInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeResearchPublicationInfo);
        }

        // GET: Employee/EmployeeResearchPublicationInfo/Create
        public ActionResult Create()
        {
            ViewBag.BookTypeId = new SelectList(db.BookTypes, "BookTypeId", "BookTypeName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode");
            return View();
        }

        // POST: Employee/EmployeeResearchPublicationInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeResearchPublicationInfoId,EmployeeInfoId,ResearchPublicationTitle,BookName,BookPublishBy,BookTypeId,CountryId,BookISSNumber,BookPublishedDate")] EmployeeResearchPublicationInfo employeeResearchPublicationInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeResearchPublicationInfoes.Add(employeeResearchPublicationInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookTypeId = new SelectList(db.BookTypes, "BookTypeId", "BookTypeName", employeeResearchPublicationInfo.BookTypeId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", employeeResearchPublicationInfo.CountryId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeResearchPublicationInfo.EmployeeInfoId);
            return View(employeeResearchPublicationInfo);
        }

        // GET: Employee/EmployeeResearchPublicationInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeResearchPublicationInfo employeeResearchPublicationInfo = db.EmployeeResearchPublicationInfoes.Find(id);
            if (employeeResearchPublicationInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookTypeId = new SelectList(db.BookTypes, "BookTypeId", "BookTypeName", employeeResearchPublicationInfo.BookTypeId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", employeeResearchPublicationInfo.CountryId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeResearchPublicationInfo.EmployeeInfoId);
            return View(employeeResearchPublicationInfo);
        }

        // POST: Employee/EmployeeResearchPublicationInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeResearchPublicationInfoId,EmployeeInfoId,ResearchPublicationTitle,BookName,BookPublishBy,BookTypeId,CountryId,BookISSNumber,BookPublishedDate")] EmployeeResearchPublicationInfo employeeResearchPublicationInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeResearchPublicationInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookTypeId = new SelectList(db.BookTypes, "BookTypeId", "BookTypeName", employeeResearchPublicationInfo.BookTypeId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", employeeResearchPublicationInfo.CountryId);
            ViewBag.EmployeeInfoId = new SelectList(db.EmployeeInfoes, "EmployeeInfoId", "EmployeeCode", employeeResearchPublicationInfo.EmployeeInfoId);
            return View(employeeResearchPublicationInfo);
        }

        // GET: Employee/EmployeeResearchPublicationInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeResearchPublicationInfo employeeResearchPublicationInfo = db.EmployeeResearchPublicationInfoes.Find(id);
            if (employeeResearchPublicationInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeResearchPublicationInfo);
        }

        // POST: Employee/EmployeeResearchPublicationInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeResearchPublicationInfo employeeResearchPublicationInfo = db.EmployeeResearchPublicationInfoes.Find(id);
            db.EmployeeResearchPublicationInfoes.Remove(employeeResearchPublicationInfo);
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
