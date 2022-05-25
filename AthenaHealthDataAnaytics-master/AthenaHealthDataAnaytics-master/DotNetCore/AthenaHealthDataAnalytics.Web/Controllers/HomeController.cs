using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AthenaHealthDataAnalytics.Web.Models;
using log4net;
using AthenaHealthDataAnalytics.Core.EntityModels;
using AthenaHealthDataAnalytics.Core.ViewModels;
using BLL.AthenaClient;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace AthenaHealthDataAnalytics.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Global Variable Declaration
        private readonly ILog _log;
        #endregion

        #region Constructor
        public HomeController(IAthenaPatientDataManager athenaPatientDataManager, IAthenaHealthApiManager athenaHealthApiManager)
        {
            _athenaHealthApiManager = athenaHealthApiManager;
            _log = LogManager.GetLogger(typeof(HomeController));
        }
        public IAthenaHealthApiManager _athenaHealthApiManager { get; set; }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
