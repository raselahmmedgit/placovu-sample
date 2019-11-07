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
    public class SurgicalConciergeController : Controller
    {
        SurgicalConciergeDbContext _db = new SurgicalConciergeDbContext();

        // GET: SurgicalConcierge
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetWorkFlowListAjax(DataTableProperty param)
        {
            var dataList = GetWorkFlowProcedureViewModel();

            int totalRecord = dataList == null ? 0 : dataList.Count();

            //var data = dataList.Select(item => new[] { item.WorkFlowCategoryName, item.ProcedureName, item.WorkFlowName, (item.StartDateTime != null ? item.StartDateTime.Value.ToString("G") : string.Empty ), (item.EndDateTime != null ? item.EndDateTime.Value.ToString("G") : string.Empty), (item.IsActive != null ? (item.IsActive == true ? "Running" : "Stop") : string.Empty), item.WorkFlowId.ToString(), item.ProcedureId.ToString(), item.WorkFlowProcedureId.ToString(), (item.IsActive == true ? "End" : "Start"), (item.IsActive != null ? item.IsActive.ToString() : string.Empty) });

            var data = dataList.Select(item => new[] { item.WorkFlowName, (item.StartDateTime != null ? item.StartDateTime.Value.ToString("G") : string.Empty), (item.EndDateTime != null ? item.EndDateTime.Value.ToString("G") : string.Empty), GetActiveStatus(item.IsActive), item.WorkFlowId.ToString(), item.ProcedureId.ToString(), item.WorkFlowProcedureId.ToString(), GetStatus(item.HasStart, item.HasEnd), (item.HasStart != null ? item.HasStart.ToString() : string.Empty), (item.HasEnd != null ? item.HasEnd.ToString() : string.Empty), item.WorkFlowPatientProfileId.ToString() });


            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = totalRecord,
                iTotalDisplayRecords = totalRecord,
                aaData = data
            }, JsonRequestBehavior.AllowGet);
        }

        private string GetActiveStatus(bool? isActive)
        {
            string strStatus = string.Empty;

            if (isActive == null)
            {

            }
            else
            {
                if (isActive == true)
                {
                    strStatus = "Running";
                }
                else
                {
                    strStatus = "Stop";
                }
            }
            return strStatus;
        }

        private string GetStatus(bool? hasStart, bool? hasEnd)
        {
            string strStatus = string.Empty;

            if (hasStart == null && hasEnd == null)
            {
                strStatus = "Start";
            }
            else
            {
                if (hasStart == true && hasEnd == true)
                {
                    strStatus = "Done";
                }
                else if (hasStart == true && hasEnd == false)
                {
                    strStatus = "End";
                }
                else if (hasStart == true && hasEnd == null)
                {
                    strStatus = "End";
                }
            }
            return strStatus;
        }

        [HttpGet]
        public ActionResult GetWorkFlowAjax(int workFlowId, int procedureId, int workFlowProcedureId)
        {
            string strMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    strMessage = MessageResourceHelper.Save;
                }
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
            }

            return Json(strMessage, JsonRequestBehavior.AllowGet);

        }

        //[HttpPost]
        //public ActionResult PostWorkFlowAjax(int workFlowId, int procedureId, int workFlowProcedureId)
        //{
        //    string strMessage = string.Empty;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var runningWorkFlowPatientProfile = _db.WorkFlowPatientProfile.SingleOrDefault(item => item.IsActive == true);
        //            if (runningWorkFlowPatientProfile != null)
        //            {
        //                runningWorkFlowPatientProfile.IsActive = false;
        //                _db.Entry(runningWorkFlowPatientProfile).State = EntityState.Modified;
        //            }

        //            var workFlowPatientProfile = new WorkFlowPatientProfile() { WorkFlowId = workFlowId, PatientProfileId = 1, StartDateTime = DateTime.UtcNow, EndDateTime = DateTime.UtcNow, IsActive = true };
        //            _db.WorkFlowPatientProfile.Add(workFlowPatientProfile);

        //            _db.SaveChanges();

        //            strMessage = MessageResourceHelper.Save;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        strMessage = ex.Message;
        //    }

        //    return Json(strMessage, JsonRequestBehavior.AllowGet);

        //}

        [HttpPost]
        public ActionResult PostWorkFlowAjax(WorkFlowProcedureViewModel model)
        {
            string strMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.HasStart == true && model.WorkFlowPatientProfileId > 0)
                    {
                        var runningWorkFlowPatientProfile = _db.WorkFlowPatientProfiles.SingleOrDefault(item => item.WorkFlowPatientProfileId == model.WorkFlowPatientProfileId && item.IsActive == true);
                        if (runningWorkFlowPatientProfile != null)
                        {
                            runningWorkFlowPatientProfile.EndDateTime = model.CurrentDataTime;
                            runningWorkFlowPatientProfile.HasEnd = true;
                            runningWorkFlowPatientProfile.IsActive = false;
                            _db.Entry(runningWorkFlowPatientProfile).State = EntityState.Modified;
                            _db.SaveChanges();
                            SendEmail(model.WorkFlowName, model.CurrentDataTime, GetStatus(model.HasStart, model.HasEnd));
                        }

                    }
                    else
                    {
                        var workFlowPatientProfile = new WorkFlowPatientProfile() { WorkFlowId = model.WorkFlowId, PatientProfileId = 1, StartDateTime = model.CurrentDataTime, HasStart = true, IsActive = true };
                        _db.WorkFlowPatientProfiles.Add(workFlowPatientProfile);
                        _db.SaveChanges();
                        SendEmail(model.WorkFlowName, model.CurrentDataTime, GetStatus(model.HasStart, model.HasEnd));
                    }



                    strMessage = MessageResourceHelper.Save;
                }
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
            }

            return Json(strMessage, JsonRequestBehavior.AllowGet);

        }

        private List<WorkFlowProcedureViewModel> GetWorkFlowProcedureViewModel()
        {
            //string sqlQuery = "select distinct wf.WorkFlowId WorkFlowId, wf.[Name] WorkFlowName, wfp.WorkFlowProcedureId WorkFlowProcedureId, wfp.ProcedureId ProcedureId, p.[Name] ProcedureName, wfc.WorkFlowCategoryId WorkFlowCategoryId, wfc.[Name] WorkFlowCategoryName, wfpp.StartDateTime StartDateTime, wfpp.EndDateTime EndDateTime, wfpp.IsActive IsActive, wfpp.HasStart HasStart, wfpp.HasEnd HasEnd, wfpp.WorkFlowPatientProfileId WorkFlowPatientProfileId from WorkFlow wf inner join WorkFlowProcedure wfp on wfp.WorkFlowId = wf.WorkFlowId inner join WorkFlowCategory wfc on wfc.WorkFlowCategoryId = wf.WorkFlowCategoryId inner join[Procedure] p on p.ProcedureId = wfp.ProcedureId left join WorkFlowPatientProfile wfpp on wfpp.WorkFlowId = wf.WorkFlowId and wfpp.IsActive = 1 and wfpp.PatientProfileId = 1";

            string sqlQuery = "select distinct wf.WorkFlowId WorkFlowId, wf.[Name] WorkFlowName, wfp.WorkFlowProcedureId WorkFlowProcedureId, wfp.ProcedureId ProcedureId, p.[Name] ProcedureName, wfc.WorkFlowCategoryId WorkFlowCategoryId, wfc.[Name] WorkFlowCategoryName, wfpp.StartDateTime StartDateTime, wfpp.EndDateTime EndDateTime, wfpp.IsActive IsActive, wfpp.HasStart HasStart, wfpp.HasEnd HasEnd, isnull(wfpp.WorkFlowPatientProfileId,0) WorkFlowPatientProfileId from WorkFlow wf inner join WorkFlowProcedure wfp on wfp.WorkFlowId = wf.WorkFlowId inner join WorkFlowCategory wfc on wfc.WorkFlowCategoryId = wf.WorkFlowCategoryId inner join[Procedure] p on p.ProcedureId = wfp.ProcedureId left join WorkFlowPatientProfile wfpp on wfpp.WorkFlowId = wf.WorkFlowId and wfpp.PatientProfileId = 1";

            var result = _db.Database.SqlQuery<WorkFlowProcedureViewModel>(sqlQuery).ToList();
            return result;
        }

        private bool SendEmail(string workFlowName, DateTime? currentDataTime, string currentStatus)
        {

            try
            {
                //from, to
                MailMessage mail = new MailMessage("rasel.placovu@gmail.com", "rasel.placovu2@hotmail.com");
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.google.com";
                mail.Subject = "Surgical Concierge";
                mail.Body = "Hi, Surgical Concierge, State Name: " + workFlowName + " Status: " + currentStatus + " Datetime: " + currentDataTime.Value.ToString("G");
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}