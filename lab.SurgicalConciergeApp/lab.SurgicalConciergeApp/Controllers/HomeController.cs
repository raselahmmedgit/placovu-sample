﻿using lab.SurgicalConciergeApp.Helpers;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
                
        public ActionResult Video()
        {
            return View();
        }
    }
}