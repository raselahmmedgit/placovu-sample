using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab.SecurityApp.Models;
using lab.SecurityApp.Service;
using lab.SecurityApp.Helpers;
using lab.SecurityApp.Helpers.DataTables;
using lab.SecurityApp.ViewModels;

namespace lab.SecurityApp.Controllers
{
    public class ApplicationInfoController : Controller
    {
        #region Global Variable Declaration
        private readonly IApplicationInfoService _iApplicationInfoService;
        #endregion

        #region Constructor
        public ApplicationInfoController(IApplicationInfoService iApplicationInfoService)
        {
            _iApplicationInfoService = iApplicationInfoService;
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
                var list = _iApplicationInfoService.GetAllBySearch(param);

                var result = list.Select(item => new[] { item.Name, item.Key, item.Value, Convert.ToString(item.ApplicationInfoId) });

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
                var applicationInfo = new ApplicationInfo();
                if (id == null)
                {
                    return PartialView(applicationInfo);
                }
                else {
                    applicationInfo = _iApplicationInfoService.GetById(Convert.ToInt32(id));
                    return PartialView(applicationInfo);
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
                var applicationInfo = _iApplicationInfoService.GetById(Convert.ToInt32(id));
                if (applicationInfo == null)
                {
                    return HttpNotFound();
                }

                return Json(applicationInfo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult SaveAjax(ApplicationInfoViewModel applicationInfoViewModel)
        {
            try
            {
                AppMessage message;

                if (ModelState.IsValid)
                {
                    message = _iApplicationInfoService.InsertOrUpdate(applicationInfoViewModel);
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
                var applicationInfo = _iApplicationInfoService.GetById(Convert.ToInt32(id));
                if (applicationInfo == null)
                {
                    return HttpNotFound();
                }

                var message = _iApplicationInfoService.Delete(applicationInfo);

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
