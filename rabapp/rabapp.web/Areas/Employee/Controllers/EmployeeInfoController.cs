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
    public class EmployeeInfoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employee/EmployeeInfo
        public ActionResult Index()
        {
            var employees = db.EmployeeInfoes.Include(e => e.BloodGroup).Include(e => e.District).Include(e => e.FreedomFighterRelationshipType).Include(e => e.FreedomFighterType).Include(e => e.GenderType).Include(e => e.NationalIdPicture).Include(e => e.ProfilePicture).Include(e => e.ReligionType).Include(e => e.SignaturePicture);
            return View(employees.ToList());
        }

        // GET: Employee/EmployeeInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        // GET: Employee/EmployeeInfo/Create
        public ActionResult Create()
        {
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodGroupId", "BloodGroupName");
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName");
            ViewBag.FreedomFighterRelationshipTypeId = new SelectList(db.FreedomFighterRelationshipTypes, "FreedomFighterRelationshipTypeId", "FreedomFighterRelationshipTypeName");
            ViewBag.FreedomFighterTypeId = new SelectList(db.FreedomFighterTypes, "FreedomFighterTypeId", "FreedomFighterTypeName");
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName");
            ViewBag.NationalIdPictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType");
            ViewBag.ProfilePictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType");
            ViewBag.ReligionTypeId = new SelectList(db.ReligionTypes, "ReligionTypeId", "ReligionTypeName");
            ViewBag.SignaturePictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType");
            return View();
        }

        // POST: Employee/EmployeeInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeInfoId,EmployeeCode,EmployeeName,EmployeeFatherName,EmployeeMotherName,DateOfBirth,PrimaryPhone,PrimaryPhoneCode,PrimaryPhoneCountryId,OtherPhone,OtherPhoneCode,OtherPhoneCountryId,EmailAddress,DistrictId,GenderTypeId,ReligionTypeId,BloodGroupId,ProfilePictureId,NationalIdPictureId,FreedomFighterTypeId,FreedomFighterRelationshipTypeId,FreedomFighterId,PassportNumber,PassportExpiryDate,SignaturePictureId,BirthCertificateNumber,LastDayWork,IsPoliceVerified,PresentAddress,PermanantAddress")] EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeInfoes.Add(employeeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodGroupId", "BloodGroupName", employeeInfo.BloodGroupId);
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", employeeInfo.DistrictId);
            ViewBag.FreedomFighterRelationshipTypeId = new SelectList(db.FreedomFighterRelationshipTypes, "FreedomFighterRelationshipTypeId", "FreedomFighterRelationshipTypeName", employeeInfo.FreedomFighterRelationshipTypeId);
            ViewBag.FreedomFighterTypeId = new SelectList(db.FreedomFighterTypes, "FreedomFighterTypeId", "FreedomFighterTypeName", employeeInfo.FreedomFighterTypeId);
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName", employeeInfo.GenderTypeId);
            ViewBag.NationalIdPictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeInfo.NationalIdPictureId);
            ViewBag.ProfilePictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeInfo.ProfilePictureId);
            ViewBag.ReligionTypeId = new SelectList(db.ReligionTypes, "ReligionTypeId", "ReligionTypeName", employeeInfo.ReligionTypeId);
            ViewBag.SignaturePictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeInfo.SignaturePictureId);
            return View(employeeInfo);
        }

        // GET: Employee/EmployeeInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodGroupId", "BloodGroupName", employeeInfo.BloodGroupId);
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", employeeInfo.DistrictId);
            ViewBag.FreedomFighterRelationshipTypeId = new SelectList(db.FreedomFighterRelationshipTypes, "FreedomFighterRelationshipTypeId", "FreedomFighterRelationshipTypeName", employeeInfo.FreedomFighterRelationshipTypeId);
            ViewBag.FreedomFighterTypeId = new SelectList(db.FreedomFighterTypes, "FreedomFighterTypeId", "FreedomFighterTypeName", employeeInfo.FreedomFighterTypeId);
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName", employeeInfo.GenderTypeId);
            ViewBag.NationalIdPictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeInfo.NationalIdPictureId);
            ViewBag.ProfilePictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeInfo.ProfilePictureId);
            ViewBag.ReligionTypeId = new SelectList(db.ReligionTypes, "ReligionTypeId", "ReligionTypeName", employeeInfo.ReligionTypeId);
            ViewBag.SignaturePictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeInfo.SignaturePictureId);
            return View(employeeInfo);
        }

        // POST: Employee/EmployeeInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeInfoId,EmployeeCode,EmployeeName,EmployeeFatherName,EmployeeMotherName,DateOfBirth,PrimaryPhone,PrimaryPhoneCode,PrimaryPhoneCountryId,OtherPhone,OtherPhoneCode,OtherPhoneCountryId,EmailAddress,DistrictId,GenderTypeId,ReligionTypeId,BloodGroupId,ProfilePictureId,NationalIdPictureId,FreedomFighterTypeId,FreedomFighterRelationshipTypeId,FreedomFighterId,PassportNumber,PassportExpiryDate,SignaturePictureId,BirthCertificateNumber,LastDayWork,IsPoliceVerified,PresentAddress,PermanantAddress")] EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodGroupId", "BloodGroupName", employeeInfo.BloodGroupId);
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", employeeInfo.DistrictId);
            ViewBag.FreedomFighterRelationshipTypeId = new SelectList(db.FreedomFighterRelationshipTypes, "FreedomFighterRelationshipTypeId", "FreedomFighterRelationshipTypeName", employeeInfo.FreedomFighterRelationshipTypeId);
            ViewBag.FreedomFighterTypeId = new SelectList(db.FreedomFighterTypes, "FreedomFighterTypeId", "FreedomFighterTypeName", employeeInfo.FreedomFighterTypeId);
            ViewBag.GenderTypeId = new SelectList(db.GenderTypes, "GenderTypeId", "GenderTypeName", employeeInfo.GenderTypeId);
            ViewBag.NationalIdPictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeInfo.NationalIdPictureId);
            ViewBag.ProfilePictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeInfo.ProfilePictureId);
            ViewBag.ReligionTypeId = new SelectList(db.ReligionTypes, "ReligionTypeId", "ReligionTypeName", employeeInfo.ReligionTypeId);
            ViewBag.SignaturePictureId = new SelectList(db.BaseDocuments, "DocumentId", "DocumentType", employeeInfo.SignaturePictureId);
            return View(employeeInfo);
        }

        // GET: Employee/EmployeeInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        // POST: Employee/EmployeeInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            db.EmployeeInfoes.Remove(employeeInfo);
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
