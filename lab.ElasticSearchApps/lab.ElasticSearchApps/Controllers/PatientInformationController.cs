using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab.ElasticSearchApps.Models;
using lab.ElasticSearchApps.Helpers;

namespace lab.ElasticSearchApps.Controllers
{
    public class PatientInformationController : Controller
    {
        private AppDbContext db = new AppDbContext();
        private PatientInformationRepository _patientInformationRepository;

        public PatientInformationController() {
            _patientInformationRepository = new PatientInformationRepository();
        }

        // GET: PatientInformation
        public ActionResult Index()
        {
            var dataList = _patientInformationRepository.Search(10, 1);
            return View(dataList);
        }

        // GET: PatientInformation
        public ActionResult Search()
        {
            var dataList = _patientInformationRepository.Search(10, 1);
            return View(dataList);
        }

        [HttpGet]
        public ActionResult GetListAjax(DataTableProperty param)
        {
            int totalRecord = _patientInformationRepository.TotalCount();
            var patientList = _patientInformationRepository.Search(param.iDisplayLength, param.iDisplayStart);

            //var data = patientList.Select(patient => new[] { patient.PatientIdDisplay, patient.PatientBirthYearMonth, patient.PatientId.ToString() });
            var data = patientList.Select(patient => new[] { patient.PatientId.ToString(), patient.PatientBirthYearMonth, patient.PatientId.ToString() });

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = totalRecord,
                iTotalDisplayRecords = totalRecord,
                aaData = data
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: PatientInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientInformation patientInformation = db.PatientInformations.Find(id);
            if (patientInformation == null)
            {
                return HttpNotFound();
            }
            return View(patientInformation);
        }

        // GET: PatientInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,PatientIdDisplay,PatientBirthYear,PatientBirthMonth,PatientBirthYearMonth,CreatedDate,OrganizationId")] PatientInformation patientInformation)
        {
            if (ModelState.IsValid)
            {
                db.PatientInformations.Add(patientInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientInformation);
        }

        // GET: PatientInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientInformation patientInformation = db.PatientInformations.Find(id);
            if (patientInformation == null)
            {
                return HttpNotFound();
            }
            return View(patientInformation);
        }

        // POST: PatientInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientId,PatientIdDisplay,PatientBirthYear,PatientBirthMonth,PatientBirthYearMonth,CreatedDate,OrganizationId")] PatientInformation patientInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientInformation);
        }

        // GET: PatientInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientInformation patientInformation = db.PatientInformations.Find(id);
            if (patientInformation == null)
            {
                return HttpNotFound();
            }
            return View(patientInformation);
        }

        // POST: PatientInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientInformation patientInformation = db.PatientInformations.Find(id);
            db.PatientInformations.Remove(patientInformation);
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
