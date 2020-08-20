using lRnD.AzureLoadBalancer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RnD.AzureLoadBalancer.Controllers
{
    public class HomeController : Controller
    {
        OntrackHealthEntities ontrackHealthEntities = new OntrackHealthEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            try
            {
                var list = ontrackHealthEntities.ApplicationSettings.ToList().AsEnumerable();
                return View(list);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}