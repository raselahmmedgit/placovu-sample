using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface;
using AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Service;
using AthenaHealthDataAnalytics.Core.BLL.MongoDBClient;
using AthenaHealthDataAnalytics.Core.DAL;
using AthenaHealthDataAnalytics.Core.DAL.Interfaces;
using AthenaHealthDataAnalytics.Core.EntityModels;
using BLL.AthenaClient;
using log4net;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AthenaHealthDataAnalytics.Core.ViewModels;

namespace AthenaHealthDataAnalytics.Core.BLL
{
    public class AthenaPatientDataManager : IAthenaPatientDataManager
    {
        private IGetPatientHistoryChartData _patientHistoryChartData;
        private IPatientHistoryRepository _patientHistoryRepository;
        private IGetPatientDetailData _patientDetailData;
        private IPatientDetailRepository _patientDetailRepository;
        private IGetPatientDocumentData _patientDocumentData;
        private IPatientDocumentRepository _patientDocumentRepository;
        private IGetEncounterDetailData _encounterDetailData;
        private IPatientEncounterRepository _encounterRepository;
        private IGetPatientFinancialData _patientFinancialData;
        private IPatientFinancialRepository _patientFinancialRepository;
        private IPatientLabResultDocumentRepository _patientLabResultDataRepository;
        private readonly IAthenaApiHttpClient _athenaApiHttpClient;

        private ILog _log;

        public AthenaPatientDataManager(IAthenaHealthConfigs athenaHealthConfigs,
            IMongoDatabaseSettings mongoDatabseSettings, IGetPatientDocumentData getPatientDocumentData,
            IAthenaApiHttpClient athenaApiHttpClient, IGetPatientHistoryChartData patientHistoryChartData,
            IGetPatientDetailData patientDetailData, IGetEncounterDetailData encounterDetailData,
            IGetPatientFinancialData patientFinancialData)
        {
            _athenaApiHttpClient = athenaApiHttpClient;
            _log = LogManager.GetLogger(typeof(AthenaPatientDataManager));
            _patientHistoryChartData = patientHistoryChartData;
            _patientHistoryRepository = new PatientHistoryRepository(mongoDatabseSettings);
            _patientDetailData = patientDetailData;
            _patientDetailRepository = new PatientDetailRepository(mongoDatabseSettings);
            _patientDocumentData = getPatientDocumentData;
            _patientDocumentRepository = new PatientDocumentRepository(mongoDatabseSettings);
            _encounterDetailData = encounterDetailData;
            _encounterRepository = new PatientEncounterRepository(mongoDatabseSettings);
            _patientFinancialData = patientFinancialData;
            _patientFinancialRepository = new PatientFinancialRepository(mongoDatabseSettings);
            _patientLabResultDataRepository = new PatientLabResultDocumentRepository(mongoDatabseSettings);
        }

        public async Task<PatientDetailDataViewModel> GetAthenaPatientDataFromMongoDB(string patientId,
            string departmentId)
        {
            var viewModel = new PatientDetailDataViewModel
            {
                PatientEncounter = await _encounterRepository.GetItemByPatientId(patientId),
                PatientDetail = await _patientDetailRepository.GetItemByPatientId(patientId),
                PatientDocument = await _patientDocumentRepository.GetItemByPatientId(patientId),
                PatientFinancial = await _patientFinancialRepository.GetItemByPatientId(patientId),
                PatientHistory = await _patientHistoryRepository.GetItemByPatientId(patientId),
            };
            return viewModel;
        }

        public async Task InsertAthenaPatientHistoryToMongoDB(string patientId, string departmentId)
        {
            try
            {
                PatientHistory patientHistory = new PatientHistory();
                patientHistory.PatientId = patientId;
                patientHistory.DepartmentId = departmentId;
                patientHistory.PatientAllergies =
                    await _patientHistoryChartData.GetPatientAllergies(patientId, departmentId);
                patientHistory.PatientFamilyHistor =
                    await _patientHistoryChartData.GetPatientFamilyHistory(patientId, departmentId);
                patientHistory.PatientGynHistory =
                    await _patientHistoryChartData.GetPatientGynHistory(patientId, departmentId);
                patientHistory.PatientSocialHistory =
                    await _patientHistoryChartData.GetPatientSocialHistory(patientId, departmentId);
                patientHistory.PatientSurgicalHistory =
                    await _patientHistoryChartData.GetPatientSurgicalHistory(patientId, departmentId);
                patientHistory.PatientVaccines =
                    await _patientHistoryChartData.GetPatientVaccines(patientId, departmentId);
                patientHistory.PatientVitals = await _patientHistoryChartData.GetPatientVitals(patientId, departmentId);
                patientHistory.PatientCcda = await _patientHistoryChartData.GetPatientCcda(patientId, departmentId);
                patientHistory.PatientPharmaciesDefault =
                    await _patientHistoryChartData.GetPatientPharmaciesDefault(patientId, departmentId);
                patientHistory.PatientMedications =
                    await _patientHistoryChartData.GetPatientMedications(patientId, departmentId);
                patientHistory.PatientLabsDefault =
                    await _patientHistoryChartData.GetPatientLabsDefault(patientId, departmentId);
                patientHistory.PatientCareTeam =
                    await _patientHistoryChartData.GetPatientCareTeam(patientId, departmentId);
                patientHistory.PatientPharmaciesPreferred =
                    await _patientHistoryChartData.GetPatientPharmaciesPreferred(patientId, departmentId);
                patientHistory.PatientProblems =
                    await _patientHistoryChartData.GetPatientProblems(patientId, departmentId);
                patientHistory.PatientQualityManagement =
                    await _patientHistoryChartData.GetPatientQualityManagement(patientId, departmentId);
                patientHistory.PatientQualityManagementProviders =
                    await _patientHistoryChartData.GetPatientQualityManagementProviders(patientId, departmentId);
                patientHistory.PatientImagingPreferred =
                    await _patientHistoryChartData.GetPatientImagingPreferred(patientId, departmentId);
                patientHistory.PatientLabResults =
                    await _patientHistoryChartData.GetPatientLabResults(patientId, departmentId);
                patientHistory.PatientAnalytes =
                    await _patientHistoryChartData.GetPatientAnalytes(patientId, departmentId);
                patientHistory.PatientAdministeredQuestionnaireScreeners =
                    await _patientHistoryChartData
                        .GetPatientAdministeredQuestionnaireScreeners(patientId, departmentId);
                patientHistory.TimeStamp = DateTime.Now.ToString();
                await _patientHistoryRepository.InsertItem(patientHistory);
                _log.Info($"Inserted patient history for patientId: {patientId} and departmentId: {departmentId}");
            }
            catch (Exception ex)
            {
                _log.Error("Error in insert patient history, ex: " + ex);
            }
        }

        public async Task InsertAthenaPatientFinancialToMongoDB(string patientId, string departmentId)
        {
            try
            {
                PatientFinancial patientFinancial = new PatientFinancial
                {
                    PatientId = patientId,
                    DepartmentId = departmentId,
                    PatientInsurance = await _patientFinancialData.GetPatientInsurance(patientId),
                    PatientClaimsClosed = await _patientFinancialData.GetPatientClaimsClosed(patientId, departmentId),
                    PatientClaimsOutstanding =
                        await _patientFinancialData.GetPatientClaimsOutstanding(patientId, departmentId),
                    PatientReferralAuths = await _patientFinancialData.GetPatientReferralAuths(patientId),
                    PatientContractsOneYear =
                        await _patientFinancialData.GetPatientContractsOneYear(patientId, departmentId),
                    PatientContractsPaymentPlan =
                        await _patientFinancialData.GetPatientContractsPaymentPlan(patientId, departmentId),
                    PatientContractsStoredCard =
                        await _patientFinancialData.GetPatientContractsStoredCard(patientId, departmentId),
                    PatientEPaymentReceipts =
                        await _patientFinancialData.GetPatientEPaymentReceipts(patientId, departmentId),
                    //                    PatientInsuranceBenefitDetails = await _patientFinancial.GetPatientInsuranceBenefitDetails(patientId,String.Empty),
                    //                    PatientEPaymentReceiptsDetails = await _patientFinancial.GetPatientEPaymentReceiptsDetails(patientId,string.Empty),
                    //                    PatientInsuranceCcmEnrollmentStatus = await _patientFinancial.GetPatientInsuranceCcmEnrollmentStatus(patientId,departmentId,string.Empty),
                    //                    PatientContractsOneYearByAppointmentId = await _patientFinancial.GetPatientContractsOneYearByAppointmentId(patientId,departmentId,string.Empty),
                };
                patientFinancial.PatientId = patientId;
                patientFinancial.DepartmentId = departmentId;
                patientFinancial.TimeStamp = DateTime.Now.ToString();
                await _patientFinancialRepository.InsertItem(patientFinancial);
                _log.Info(
                    $"Inserted patient financial data for patientId: {patientId} and departmentId: {departmentId}");
            }
            catch (Exception ex)
            {
                _log.Error("Error in insert financial data, ex: " + ex);
            }
        }

        public async Task InsertAthenaEncounterDataToMongoDB(string patientId, string departmentId)
        {
            try
            {
                var encounterList = await _patientHistoryChartData.GetPatientEncounter(patientId, departmentId);
                if (encounterList != null && encounterList.Count > 0)
                {
                    foreach (var item in encounterList)
                    {
                        var encounterId = item.GetValue("encounterid").ToString();
                        var encounterDiagnoses = await _encounterDetailData.GetEncounterDiagnoses(encounterId);
                        if (encounterDiagnoses != null)
                        {
                            item.Add("encounterDiagnoses", new BsonArray(encounterDiagnoses));
                        }

                        var encounterDescription = await _encounterDetailData.GetEncounterDescription(encounterId);
                        if (encounterDescription != null)
                        {
                            item.Add("encounterDescription", new BsonArray(encounterDescription));
                        }

                        var encounterAssessment = await _encounterDetailData.GetEncounterAssessment(encounterId);
                        if (encounterAssessment != null)
                        {
                            item.Add("encounterAssessment", encounterAssessment);
                        }

                        var encounterDefaultSearchFacilities =
                            await _encounterDetailData.GetEncounterDefaultSearchFacilities(encounterId);
                        if (encounterDefaultSearchFacilities != null)
                        {
                            item.Add("encounterDefaultSearchFacilities", encounterDefaultSearchFacilities);
                        }

                        var encounterHpi = await _encounterDetailData.GetEncounterHpi(encounterId);
                        if (encounterHpi != null)
                        {
                            item.Add("encounterHpi", encounterHpi);
                        }

                        var encounterOrders = await _encounterDetailData.GetEncounterOrders(encounterId);
                        if (encounterOrders != null)
                        {
                            item.Add("encounterOrders", new BsonArray(encounterOrders));
                        }

                        var encounterPhysicalExam = await _encounterDetailData.GetEncounterPhysicalExam(encounterId);
                        if (encounterPhysicalExam != null)
                        {
                            item.Add("encounterPhysicalExam", encounterPhysicalExam);
                        }

                        var encounterProcedureDocumentation =
                            await _encounterDetailData.GetEncounterProcedureDocumentation(encounterId);
                        if (encounterProcedureDocumentation != null)
                        {
                            item.Add("encounterProcedureDocumentation", new BsonArray(encounterProcedureDocumentation));
                        }

                        var encounterVitals = await _encounterDetailData.GetEncounterVitals(encounterId);
                        if (encounterVitals != null)
                        {
                            item.Add("encounterVitals", new BsonArray(encounterVitals));
                        }
                    }
                }

                PatientEncounter patientEncounter = new PatientEncounter();
                patientEncounter.PatientId = patientId;
                patientEncounter.DepartmentId = departmentId;
                patientEncounter.Encounters = encounterList;
                patientEncounter.TimeStamp = DateTime.Now.ToString();
                await _encounterRepository.InsertItem(patientEncounter);
                _log.Info($"Inserted patient history for patientId: {patientId} and departmentId: {departmentId}");
            }
            catch (Exception ex)
            {
                _log.Error("Error in insert encounter, ex: " + ex);
            }
        }

        public async Task InsertAthenaPatientDocumentDataToMongoDB(string patientId, string departmentId)
        {
            try
            {
                var documentList = await _patientDocumentData.GetPatientDocuments(patientId, departmentId);
                PatientDocument patientDocument = new PatientDocument();
                patientDocument.PatientId = patientId;
                patientDocument.DepartmentId = departmentId;
                patientDocument.Documents = documentList;
                patientDocument.TimeStamp = DateTime.Now.ToString();

                await _patientDocumentRepository.InsertItem(patientDocument);
                _log.Info($"Inserted patient document for patientId: {patientId} and departmentId: {departmentId}");
                await InsertLabResultToMongoDB(documentList, patientId, departmentId);
            }
            catch (Exception ex)
            {
                _log.Error("Error in InsertAthenaDocumentDataToMongoDB, ex: " + ex);
            }
        }

        private async Task InsertLabResultToMongoDB(List<BsonDocument> documentList, string patientId,
            string departmentId)
        {
            try
            {
                var Base64ImagePrefix = "data:image/png;base64,";
                var labResultDocuments = new List<PatientLabResultDocument>();
                var labResultIds = documentList.FindAll(e => e.Names.Contains("labresultid"))
                    .Select(e => e.GetValue("labresultid").AsString).ToList();
                foreach (var labResultId in labResultIds)
                {
                    var labresultDetail = await _patientDocumentData.GetPatientLabResultDetail(patientId, labResultId);
                    if (labresultDetail != null)
                    {
                        var labresultPages = labresultDetail.FindAll(e => e.Names.Contains("pages"))
                            .SelectMany(e => e.GetElement("pages").Value.AsBsonArray).Select(e => new
                            {
                                contenttype = e.AsBsonDocument.GetElement("contenttype").Value.ToString(),
                                pageordering = e.AsBsonDocument.GetElement("pageordering").Value.ToString(),
                                pageid = e.AsBsonDocument.GetElement("pageid").Value.ToString(),
                                href = e.AsBsonDocument.GetElement("href").Value.ToString(),
                            }).ToList();
                        var labResultPageData = new List<BsonDocument>();
                        foreach (var page in labresultPages)
                        {
                            labResultPageData.Add(new BsonDocument
                            {
                                {"pageordering", page.pageordering},
                                {"contenttype", page.contenttype},
                                {"pageid", page.pageid},
                                {"imagelink", page.href},
                                {"base64stringimage", Base64ImagePrefix + await _athenaApiHttpClient.GetFileAsBase64String(page.href)}
                            });
                        }

                        labResultDocuments.Add(new PatientLabResultDocument
                        {
                            PatientId = patientId,
                            DepartmentId = departmentId,
                            LabResultId = labResultId,
                            LabResultPages = labResultPageData,
                            LabResultDetails = labresultDetail,
                            TimeStamp = DateTime.Now.ToString(),
                        });
                    }
                }

                await _patientLabResultDataRepository.InsertItemCollection(labResultDocuments);
                _log.Info($"Inserted patient labresult for patientId: {patientId} and departmentId: {departmentId}");
            }
            catch (Exception ex)
            {
                _log.Error("Error in InsertAthenaLabresultDataToMongoDB, ex: " + ex);
            }
        }

        public async Task InsertAthenaPatientDetailToMongoDB(string patientId, string departmentId)
        {
            try
            {
                PatientDetail patientDetail = new PatientDetail();
                patientDetail.PatientId = patientId;
                patientDetail.DepartmentId = departmentId;
                var patientAppointments = await _patientDetailData.GetPatientAppointment(patientId);
                if (patientAppointments != null && patientAppointments.Count > 0)
                {
                    foreach (var item in patientAppointments)
                    {
                        var appointmentId = item.GetValue("appointmentid").ToString();
                        var appointmentDetail =
                            await _patientDetailData.GetPatientAppointmentDetail(patientId, appointmentId);
                        if (appointmentDetail != null)
                        {
                            item.Add("appointmentDetail", new BsonArray(appointmentDetail));
                        }
                    }
                }

                patientDetail.PatientAppointments = patientAppointments;
                patientDetail.PatientProfile = await _patientDetailData.GetPatientProfile(patientId);
                patientDetail.PatientPhoto = await _patientDetailData.GetPatientPhoto(patientId);
                patientDetail.PatientCustomFields =
                    await _patientDetailData.GetPatientCustomFields(patientId, departmentId);
                patientDetail.PatientStatements = await _patientDetailData.GetPatientStatement(patientId, departmentId);
                patientDetail.PatientAuthorizations =
                    await _patientDetailData.GetPatientAuthorizations(patientId, departmentId);
                patientDetail.PatientChartAlert =
                    await _patientDetailData.GetPatientChartAlert(patientId, departmentId);
                patientDetail.PatientInterfaceConsents =
                    await _patientDetailData.GetPatientInterfaceConsents(patientId, departmentId);
                patientDetail.PatientPrivacyInformationVerified =
                    await _patientDetailData.GetPatientPrivacyInformationVerified(patientId, departmentId);
                patientDetail.PatientPhoto = await _patientDetailData.GetPatientPhoto(patientId);
                patientDetail.TimeStamp = DateTime.Now.ToString();

                await _patientDetailRepository.InsertItem(patientDetail);
                _log.Info($"Inserted patient detail for patientId: {patientId} and departmentId: {departmentId}");
            }
            catch (Exception ex)
            {
                _log.Error("Error in insert patient detail, ex: " + ex);
            }
        }
    }
}