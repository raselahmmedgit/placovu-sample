using AthenaHealthDataAnalytics.Core.BLL;
using AthenaHealthDataAnalytics.Core.BLL.MongoDBClient;
using AthenaHealthDataAnalytics.Core.EntityModels;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Json;
using System.Threading.Tasks;

namespace BLL.AthenaClient
{
    public interface IAthenaHealthApiManager
    {
        AthenaHealthPatient GetAthenaHealthPatient(long patientId);
        Task GetAthenaPatientData(string patientId, string departmentId);
    }
    public class AthenaHealthApiManager: IAthenaHealthApiManager
    {
        public virtual APIConnection api { get; set; }
        private readonly AthenaHealthApiConnectionManager _athenaHealthApiConnectionManager;
        private readonly IAthenaPatientDataManager _athenaPatientDataManager;

        /*private readonly PatientEncounterManager _patientEncounterManager;
        private readonly PatientDetailManager _patientDetailManager;
        private readonly PatientHistoryManager _patientHistoryManager;
        private readonly PatientFinancialManager _patientFinancialManager;
        private readonly PatientDocumentManager _patientDocumentManager;*/
        private readonly ILog _log;

        public AthenaHealthApiManager(IAthenaHealthConfigs athenaHealthConfigs, IMongoDatabaseSettings mongoDatabaseSettings, IAthenaPatientDataManager athenaPatientDataManager)
        {
            _athenaHealthApiConnectionManager = new AthenaHealthApiConnectionManager(athenaHealthConfigs);
            api = _athenaHealthApiConnectionManager.Connection;
            _athenaPatientDataManager = athenaPatientDataManager;
            
            /*_patientEncounterManager = new PatientEncounterManager(athenaHealthConfigs,mongoDatabaseSettings);
            _patientDetailManager = new PatientDetailManager(athenaHealthConfigs,mongoDatabaseSettings);
            _patientFinancialManager = new PatientFinancialManager(athenaHealthConfigs, mongoDatabaseSettings);
            _patientHistoryManager = new PatientHistoryManager(athenaHealthConfigs,mongoDatabaseSettings);
            _patientDocumentManager = new PatientDocumentManager(athenaHealthConfigs,mongoDatabaseSettings);*/
            _log = LogManager.GetLogger(typeof(AthenaHealthApiManager));
        }
        public AthenaHealthPatient GetAthenaHealthPatient(long patientId)
        {
            try
            {
                string path = $"/patients/{patientId}";
                JsonValue athenaPatient = api.GET(path);
                AthenaHealthPatient athenaHealthPatient = JsonConvert.DeserializeObject<AthenaHealthPatient>(athenaPatient.ToString());
                if (athenaHealthPatient != null)
                {
                    _log.Info($"patientIdFound: {patientId}");
                    _log.Info($"patientId Data: {athenaHealthPatient}");
                    return athenaHealthPatient;
                }
                else
                {
                    _log.Info($"No patient found for  {patientId}");
                }
                return null;
            }
            catch (Exception ex)
            {
                _log.Error("Eror in GetAthenaHealthPatient(): " + ex.ToString());
            }
            return null;

        }
        public async Task GetAthenaPatientData(string patientId,string departmentId)
        {
            try
            {
                await _athenaPatientDataManager.InsertAthenaEncounterDataToMongoDB(patientId,departmentId);
                await _athenaPatientDataManager.InsertAthenaPatientDetailToMongoDB(patientId,departmentId);
                await _athenaPatientDataManager.InsertAthenaPatientFinancialToMongoDB(patientId,departmentId);
                await _athenaPatientDataManager.InsertAthenaPatientDocumentDataToMongoDB(patientId,departmentId);
                await _athenaPatientDataManager.InsertAthenaPatientHistoryToMongoDB(patientId,departmentId);
            }
            catch(Exception ex)
            {
                _log.Error("GetAthenaPatientData: " + ex);
            }
        }
    }
}