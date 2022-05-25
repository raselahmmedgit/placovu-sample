using AthenaHealthDataAnalytics.Core.BLL.Interface;
using AthenaHealthDataAnalytics.Core.ViewModels;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using log4net;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace AthenaHealthDataAnalytics.Web.Controllers
{
    public class AthenaPatientDataViewController : Controller
    {
        #region Global Variable Declaration
        private readonly ILog _log;
        private readonly IAthenaPatientDataViewManager _athenaPatientDataViewManager;
        #endregion

        #region Constructor
        public AthenaPatientDataViewController(IAthenaPatientDataViewManager athenaPatientDataViewManager)
        {
            _log = LogManager.GetLogger(typeof(HomeController));
            _athenaPatientDataViewManager = athenaPatientDataViewManager;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _log.Error("Error: " + ex);
            }
            return null;
        }

        public async Task<IActionResult> IndexData(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _athenaPatientDataViewManager.GetPatientDetailForDataTablesResponseAsync(request);
                return new DataTablesJsonResult(response, true);
            }
            catch (Exception ex)
            {
                _log.Error("Error: " + ex);
            }
            return null;
        }

        public async Task<IActionResult> ViewPatientDetail(string patientId)
        {

            try
            {
                var data = await _athenaPatientDataViewManager.GetPatientDetailByPatientId(patientId);
                
                var patientProfile = data?.PatientProfile;
                var patientAppointments = data?.PatientAppointments;
                var patientCustomFields = data?.PatientCustomFields;
                var patientStatements = data?.PatientStatements;
                var patientAuthorizations = data?.PatientAuthorizations;
                var patientChartAlert = data?.PatientChartAlert;
                var patientInterfaceConsents = data?.PatientInterfaceConsents;
                var patientPrivacyInformationVerified = data?.PatientPrivacyInformationVerified;

                PatientDetailViewModel patientDetailViewModel = new PatientDetailViewModel();
                patientDetailViewModel.Id = data.Id;
                patientDetailViewModel.PatientId = data.PatientId;
                patientDetailViewModel.DepartmentId = data.DepartmentId;
                if(patientProfile != null)
                {
                    patientDetailViewModel.PatientProfile = BsonTypeMapper.MapToDotNetValue(patientProfile);
                }
                if (patientAppointments != null)
                {
                    patientDetailViewModel.PatientAppointments = patientAppointments.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (patientCustomFields != null)
                {
                    patientDetailViewModel.PatientCustomFields = patientCustomFields.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (patientStatements != null)
                {
                    patientDetailViewModel.PatientStatements = patientStatements.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (patientAuthorizations != null)
                {
                    patientDetailViewModel.PatientAuthorizations = patientAuthorizations.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (patientChartAlert != null)
                {
                    patientDetailViewModel.PatientChartAlert = BsonTypeMapper.MapToDotNetValue(patientChartAlert);
                }
                if (patientInterfaceConsents != null)
                {
                    patientDetailViewModel.PatientInterfaceConsents = patientInterfaceConsents.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (patientPrivacyInformationVerified != null)
                {
                    patientDetailViewModel.PatientPrivacyInformationVerified = BsonTypeMapper.MapToDotNetValue(patientPrivacyInformationVerified);
                }

                string dataJson = JsonConvert.SerializeObject(patientDetailViewModel);
                return Json(dataJson);
            }
            catch (Exception ex)
            {
                _log.Error("Error: " + ex);
            }
            return null;
        }
        public async Task<IActionResult> ViewPatientEncounter(string patientId)
        {

            try
            {
                var data = await _athenaPatientDataViewManager.GetPatientEncounterByPatientId(patientId);

                var patientEncounters = data?.Encounters;
                var dataObjList = new List<object>();
                if (patientEncounters != null)
                {
                    dataObjList = patientEncounters.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                string dataJson = JsonConvert.SerializeObject(dataObjList);
                return Json(dataJson);
            }
            catch (Exception ex)
            {
                _log.Error("Error: " + ex);
            }
            return null;
        }
        public async Task<IActionResult> ViewPatientHistorical(string patientId)
        {

            try
            {
                var data = await _athenaPatientDataViewManager.GetPatienHistoricalByPatientId(patientId);
                PatientHistoryViewModel patientHistoryViewModel = new PatientHistoryViewModel();
                patientHistoryViewModel.Id = data.Id;
                patientHistoryViewModel.DepartmentId = data.DepartmentId;
                patientHistoryViewModel.PatientId = data.PatientId;
                if(data.PatientAllergies != null)
                {
                    patientHistoryViewModel.PatientAllergies = BsonTypeMapper.MapToDotNetValue(data.PatientAllergies);
                }
                if (data.PatientSocialHistory != null)
                {
                    patientHistoryViewModel.PatientSocialHistory = BsonTypeMapper.MapToDotNetValue(data.PatientSocialHistory);
                }
                if (data.PatientSurgicalHistory != null)
                {
                    patientHistoryViewModel.PatientSurgicalHistory = BsonTypeMapper.MapToDotNetValue(data.PatientSurgicalHistory);
                }
                if (data.PatientFamilyHistor != null)
                {
                    patientHistoryViewModel.PatientFamilyHistor = BsonTypeMapper.MapToDotNetValue(data.PatientFamilyHistor);
                }
                if (data.PatientGynHistory != null)
                {
                    patientHistoryViewModel.PatientGynHistory = BsonTypeMapper.MapToDotNetValue(data.PatientGynHistory);
                }
                if (data.PatientVaccines != null)
                {
                    patientHistoryViewModel.PatientVaccines = data.PatientVaccines.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientVitals != null)
                {
                    patientHistoryViewModel.PatientVitals = data.PatientVitals.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientCcda != null)
                {
                    patientHistoryViewModel.PatientCcda = data.PatientCcda.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientPharmaciesDefault != null)
                {
                    patientHistoryViewModel.PatientPharmaciesDefault = BsonTypeMapper.MapToDotNetValue(data.PatientPharmaciesDefault);
                }
                if (data.PatientMedications != null)
                {
                    patientHistoryViewModel.PatientMedications = BsonTypeMapper.MapToDotNetValue(data.PatientMedications);
                }
                if (data.PatientLabsDefault != null)
                {
                    patientHistoryViewModel.PatientLabsDefault = BsonTypeMapper.MapToDotNetValue(data.PatientLabsDefault);
                }
                if (data.PatientCareTeam != null)
                {
                    patientHistoryViewModel.PatientCareTeam = BsonTypeMapper.MapToDotNetValue(data.PatientCareTeam);
                }
                if (data.PatientPharmaciesPreferred != null)
                {
                    patientHistoryViewModel.PatientPharmaciesPreferred = data.PatientPharmaciesPreferred.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientProblems != null)
                {
                    patientHistoryViewModel.PatientProblems = data.PatientProblems.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientQualityManagement != null)
                {
                    patientHistoryViewModel.PatientQualityManagement = data.PatientQualityManagement.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientQualityManagementProviders != null)
                {
                    patientHistoryViewModel.PatientQualityManagementProviders = data.PatientQualityManagementProviders.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientImagingPreferred != null)
                {
                    patientHistoryViewModel.PatientImagingPreferred = data.PatientImagingPreferred.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientLabResults != null)
                {
                    patientHistoryViewModel.PatientLabResults = data.PatientLabResults.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientAnalytes != null)
                {
                    patientHistoryViewModel.PatientAnalytes = data.PatientAnalytes.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientAdministeredQuestionnaireScreeners != null)
                {
                    patientHistoryViewModel.PatientAdministeredQuestionnaireScreeners = data.PatientAdministeredQuestionnaireScreeners.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                string dataJson = JsonConvert.SerializeObject(patientHistoryViewModel);
                return Json(dataJson);
            }
            catch (Exception ex)
            {
                _log.Error("Error: " + ex);
            }
            return null;
        }
        public async Task<IActionResult> ViewPatientFinancial(string patientId)
        {

            try
            {
                var data = await _athenaPatientDataViewManager.GetPatientFinancialByPatientId(patientId);
                PatientFinancialViewModel patientFinancialViewModel = new PatientFinancialViewModel();
                patientFinancialViewModel.Id = data.Id;
                patientFinancialViewModel.DepartmentId = data.DepartmentId;
                patientFinancialViewModel.PatientId = data.PatientId;
                if (data.PatientContractsOneYear != null)
                {
                    patientFinancialViewModel.PatientContractsOneYear = data.PatientContractsOneYear.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientContractsOneYearByAppointmentId != null)
                {
                    patientFinancialViewModel.PatientContractsOneYearByAppointmentId = data.PatientContractsOneYearByAppointmentId.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientContractsPaymentPlan != null)
                {
                    patientFinancialViewModel.PatientContractsPaymentPlan = data.PatientContractsPaymentPlan.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientContractsStoredCard != null)
                {
                    patientFinancialViewModel.PatientContractsStoredCard = data.PatientContractsStoredCard.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientInsurance != null)
                {
                    patientFinancialViewModel.PatientInsurance = data.PatientInsurance.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientInsuranceCcmEnrollmentStatus != null)
                {
                    patientFinancialViewModel.PatientInsuranceCcmEnrollmentStatus = data.PatientInsuranceCcmEnrollmentStatus.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientEPaymentReceipts != null)
                {
                    patientFinancialViewModel.PatientEPaymentReceipts = data.PatientEPaymentReceipts.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                if (data.PatientReferralAuths != null)
                {
                    patientFinancialViewModel.PatientReferralAuths = data.PatientReferralAuths.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }

                if (data.PatientInsuranceBenefitDetails != null)
                {
                    patientFinancialViewModel.PatientInsuranceBenefitDetails = BsonTypeMapper.MapToDotNetValue(data.PatientInsuranceBenefitDetails);
                }
                if (data.PatientEPaymentReceiptsDetails != null)
                {
                    patientFinancialViewModel.PatientEPaymentReceiptsDetails = BsonTypeMapper.MapToDotNetValue(data.PatientEPaymentReceiptsDetails);
                }
                if (data.PatientClaimsClosed != null)
                {
                    patientFinancialViewModel.PatientClaimsClosed = BsonTypeMapper.MapToDotNetValue(data.PatientClaimsClosed);
                }
                if (data.PatientClaimsOutstanding != null)
                {
                    patientFinancialViewModel.PatientClaimsOutstanding = BsonTypeMapper.MapToDotNetValue(data.PatientClaimsOutstanding);
                }
                string dataJson = JsonConvert.SerializeObject(patientFinancialViewModel);
                return Json(dataJson);
            }
            catch (Exception ex)
            {
                _log.Error("Error: " + ex);
            }
            return null;
        }
        public async Task<IActionResult> ViewPatientDocument(string patientId)
        {

            try
            {
                var data = await _athenaPatientDataViewManager.GetPatientDocumentByPatientId(patientId);
                var patientDocuments = data?.Documents;
                var dataObjList = new List<object>();
                if (patientDocuments != null)
                {
                    dataObjList = patientDocuments.ConvertAll(BsonTypeMapper.MapToDotNetValue);
                }
                string dataJson = JsonConvert.SerializeObject(dataObjList);
                return Json(dataJson);
            }
            catch (Exception ex)
            {
                _log.Error("Error: " + ex);
            }
            return null;
        }

        
        #endregion
    }
}
