using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyPersonalSite.EntityModel;

namespace MyPersonalSite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            _PatientSurveyManager = new PatientSurveyManager();
        }
        private PatientSurveyManager _PatientSurveyManager;
        OntrackHealthEntities ctx = new OntrackHealthEntities();
        public ActionResult Index()
        {

            //var p1 = new SqlParameter("@StudentId", Guid.NewGuid());
            //var p2 = new SqlParameter("@StudentName", "A");
            //var p3 = new SqlParameter("@RegNo", "");
            //var p4 = new SqlParameter("@RetValue", "");
            //p4.Direction = ParameterDirection.Output;

            //var result = ctx.Database.ExecuteSqlCommand("SpInsertStudent @StudentId, @StudentName, @RegNo, @RetValue", p1 ,p2 , p3 ,p4);

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ExportToExcel()
        {
            var data = await _PatientSurveyManager.GetPatientSurveyActivity();

            return PartialView("_SurveyActivity", data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}