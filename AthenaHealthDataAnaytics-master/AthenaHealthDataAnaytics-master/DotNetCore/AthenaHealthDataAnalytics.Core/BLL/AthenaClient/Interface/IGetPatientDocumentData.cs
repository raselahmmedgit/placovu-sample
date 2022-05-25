using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface
{
    public interface IGetPatientDocumentData
    {
        Task<List<BsonDocument>> GetPatientDocuments(string patientId, string departmentId);
        Task<List<BsonDocument>> GetPatientLabResultDetail(string patientid, string labresultid);
        
    }
}