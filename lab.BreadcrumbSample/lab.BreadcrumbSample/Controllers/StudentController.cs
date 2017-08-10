using lab.BreadcrumbSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace lab.BreadcrumbSample.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository _studentRepository = new StudentRepository();

        // GET: Students
        public ActionResult Index()
        {
            return View(_studentRepository.GetStudents.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student course = _studentRepository.GetStudent(Convert.ToInt32(id));
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentRepository.AddStudent(course);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                //Write Error Log in here
                course.IsError = true;
                course.ErrorMessage = Constants.Messages.UnhandelledError;
            }

            return View(course);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student course = _studentRepository.GetStudent(Convert.ToInt32(id));
            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentRepository.EditStudent(course);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //Write Error Log in here
                course.IsError = true;
                course.ErrorMessage = Constants.Messages.UnhandelledError;
            }

            return View(course);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student course = _studentRepository.GetStudent(Convert.ToInt32(id));
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentRepository.DeleteStudent(id);
                }
            }
            catch (Exception ex)
            {
                //Write Error Log in here
            }

            return RedirectToAction("Index");
        }

    }
}