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

namespace lab.SecurityApp.Controllers
{
    public class RoleController : Controller
    {
        #region Global Variable Declaration
        private readonly IRoleService _iRoleService;
        #endregion

        #region Constructor
        public RoleController(IRoleService iRoleService)
        {
            _iRoleService = iRoleService;
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
                var list = _iRoleService.GetAllBySearch(param);

                var result = list.Select(item => new[] { item.RoleName, Convert.ToString(item.RoleId) });

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

        public ActionResult GetByIdAjax(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = _iRoleService.Get(new Role { RoleId = Convert.ToInt32(id) });
                if (role == null)
                {
                    return HttpNotFound();
                }

                return Json(role, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult SaveAjax(Role role)
        {
            try
            {
                Message message;

                if (ModelState.IsValid)
                {
                    message = _iRoleService.InsertOrUpdate(role);
                }
                else {
                    message = SetMessage.SetModelStateFirstOrDefaultErrorMessage(ModelState);
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
                var role = _iRoleService.Get(new Role { RoleId = Convert.ToInt32(id) });
                if (role == null)
                {
                    return HttpNotFound();
                }

                var message = _iRoleService.Delete(role);

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
