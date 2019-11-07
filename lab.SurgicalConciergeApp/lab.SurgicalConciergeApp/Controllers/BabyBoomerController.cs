using lab.SurgicalConciergeApp.Helpers;
using lab.SurgicalConciergeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace lab.SurgicalConciergeApp.Controllers
{
    public class BabyBoomerController : Controller
    {
        BabyBoomerDbContext _db = new BabyBoomerDbContext();

        // GET: BabyBoomer
        public ActionResult Index()
        {
            return View();
        }
    }
}