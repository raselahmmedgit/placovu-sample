using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChartDemoApp.Models;

namespace ChartDemoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Chart()
        {
            return View();
        }


        public JsonResult GetChartData(string chartType)
        {
            GraphProperty firstDataSetGraphProperty = new GraphProperty()
            {
                BorderColor = "#4BC0C0",
                PointBorderColor = "#4BC0C0",
                PointBackgroundColor = "#fff",
                BackgroundColor= "#4BC0C0"

            };
            GraphProperty secondDataSetGraphProperty = new GraphProperty()
            {
                BorderColor = "#70BF41",
                PointBorderColor = "#70BF41",
                PointBackgroundColor = "#fff",
                BackgroundColor= "#70BF41"

            };
            var chartData = new ChartModel()
            {
                Labels = new List<string>() { "Pre-op", "6 Weeks", "3 months", "6 months", "9 months"},
                ChartType = chartType,
                ChartName= "IPSS ( International Prostate Symptom Score)",
                Series = new List<DatasetModel>()
                {
                    new DatasetModel() {
                        DataList = new List<decimal>(){ 0,20,9,12,2},
                        LabelName = "Patient",
                        GraphProperty = firstDataSetGraphProperty

                    },
                    new DatasetModel() {
                        DataList = new List<decimal>() { 0,15,8,25,10},
                        LabelName = "All Physician Patient",
                        GraphProperty= secondDataSetGraphProperty
                    }
                }
                

            };
            chartData.Series.ForEach(c => c.GraphProperty.SetFillStatus(chartData.ChartType));
            return Json(chartData, JsonRequestBehavior.AllowGet);
        }
    }
}