using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab.SBThemeApps.Models;
using lab.SBThemeApps.Manager;
using AutoMapper;
using lab.SBThemeApps.ViewModels;
using lab.SBThemeApps.Helpers.DataTables;
using lab.SBThemeApps.Helpers;

namespace lab.SBThemeApps.Controllers
{
    public class StudentController : Controller
    {
        #region Global Variable Declaration
        //private readonly IStudentManager _iStudentManager;
        private AppDbContext db = new AppDbContext();
        #endregion

        #region Constructor
        //public StudentController(IStudentManager iStudentManager)
        //{
        //    _iStudentManager = iStudentManager;
        //}
        #endregion

        #region Actions

        // GET: Student
        //public ActionResult Index()
        //{
        //    var studentList = db.Students.ToList();
        //    return View(studentList);
        //}

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
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

        #endregion

        #region Actions

        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult GetDataTablesAjax(DataTableParamModel param)
        {
            try
            {
                var list = db.Students.ToList();

                var result = list.Select(item => new[] { item.StudentName, Convert.ToString(item.StudentId) });

                var totalRecord = list.Count();

                return Json(new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = totalRecord,
                    iTotalDisplayRecords = list.Count(),
                    aaData = result
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public PartialViewResult AddOrEditAjax(int? id)
        {
            try
            {
                var student = new Student();
                if (id == null)
                {
                    return PartialView("~/Views/Student/_AddOrEdit.cshtml", student);
                    //return PartialView("~/Views/Student/_AddOrEdit2.cshtml", student);
                }
                else
                {
                    student = db.Students.Find(id);
                    return PartialView("~/Views/Student/_AddOrEdit.cshtml", student);
                    //return PartialView("~/Views/Student/_AddOrEdit2.cshtml", student);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult GetByIdAjax(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var student = db.Students.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }

                return Json(student, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult SaveAjax(Student student)
        {
            try
            {
                AppMessage message;

                if (ModelState.IsValid)
                {
                    if (student.StudentId > 0)
                    {
                        db.Entry(student).State = EntityState.Modified;
                    }
                    else {
                        db.Students.Add(student);
                    }

                    int affectedRow = db.SaveChanges();
                    message = affectedRow > 0
                        ? SetAppMessage.SetSuccessMessage(MessageConstantHelper.SaveSuccessMessage)
                        : SetAppMessage.SetInformationMessage(MessageConstantHelper.SaveInformationMessage);
                }
                else
                {
                    message = SetAppMessage.SetModelStateFirstOrDefaultErrorMessage(ModelState);
                }

                return Json(message, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult DeleteAjax(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var student = db.Students.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }

                db.Students.Remove(student);
                int affectedRow = db.SaveChanges();
                var message = affectedRow > 0
                    ? SetAppMessage.SetSuccessMessage(MessageConstantHelper.SaveSuccessMessage)
                    : SetAppMessage.SetInformationMessage(MessageConstantHelper.SaveInformationMessage);

                return Json(message, JsonRequestBehavior.DenyGet);

            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion
    }
}