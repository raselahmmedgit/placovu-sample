using lab.SecurityApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.SecurityApp.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            try
            {
                //throw new ArgumentException();
                //throw new FileNotFoundException();
                //throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        public ActionResult IndexAjax()
        {
            try
            {
                //throw new ArgumentException();
                //throw new FileNotFoundException();
                //throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw;
            }

            return View();
        }
    }
}