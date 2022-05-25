using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface
{
    public interface IGetPatientHistoryChartData
    {
        Task<List<BsonDocument>> GetPatientEncounter(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientAdministeredQuestionnaireScreeners(string patientid, string departmentid);
        Task<BsonDocument> GetPatientAllergies(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientAnalytes(string patientid, string departmentid);
        Task<BsonDocument> GetPatientCareTeam(string patientid, string departmentid);
        Task<BsonDocument> GetPatientEncounterSummary(string patientid, string appointmentid);
        Task<BsonDocument> GetPatientFamilyHistory(string patientid, string departmentid);
        Task<BsonDocument> GetPatientGynHistory(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientImagingPreferred(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientLabResults(string patientid, string departmentid);
        Task<BsonDocument> GetPatientLabsDefault(string patientid, string departmentid);
        Task<BsonDocument> GetPatientMedicalHistory(string patientid, string departmentid);
        Task<BsonDocument> GetPatientMedications(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientChartList(string patientid);
        Task<BsonDocument> GetPatientPharmaciesDefault(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientPharmaciesPreferred(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientProblems(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientQualityManagement(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientQualityManagementProviders(string patientid, string departmentid);
        Task<BsonDocument> GetPatientSocialHistory(string patientid, string departmentid);
        Task<BsonDocument> GetPatientSurgicalHistory(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientVaccines(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientVitals(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientCcda(string patientid, string departmentid);
        
    }
    /*
     * not Included
     * GET ccda related info not included
     * GET /chart/{patientid}/gpal
     *  GET /chart/{patientid}/obepisodes
     *  GET /chart/{patientid}/obepisodes/{obepisodeid}
     * GET /chart/{patientid}/obepisodes/{obepisodeid}/flowsheet/configuration
     * GET /chart/{patientid}/perinatalhistory
     * GET /chart/{patientid}/riskcontract 
     */
     
}