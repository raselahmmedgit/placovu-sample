using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface
{
    public interface IGetPatientDetailData
    {
        Task<BsonDocument> GetPatientProfile(string patientId);
        Task<List<BsonDocument>> GetPatientAppointment(string patientId);
        Task<List<BsonDocument>> GetPatientAppointmentDetail(string patientId, string appointmentid);
        Task<List<BsonDocument>> GetPatientAuthorizations(string patientId, string departmentid);
        Task<BsonDocument> GetPatientChartAlert(string patientId, string departmentid);
        Task<List<BsonDocument>> GetPatientCustomFields(string patientId, string departmentid);
        Task<List<BsonDocument>> GetPatientInterfaceConsents(string patientId, string departmentid);
        Task<List<BsonDocument>> GetPatientStatement(string patientId, string departmentid);
        Task<BsonDocument> GetPatientPrivacyInformationVerified(string patientId, string departmentid);
        Task<BsonDocument> GetPatientPhoto(string patientid);
        
    }
}
