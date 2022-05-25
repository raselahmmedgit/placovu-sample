using System.Collections.Generic;
using System.Threading.Tasks;
using AthenaHealthDataAnalytics.Core.EntityModels;

namespace AthenaHealthDataAnalytics.Core.DAL.Interfaces
{
    public interface IPatientLabResultDocumentRepository
    {
        Task InsertItemCollection(List<PatientLabResultDocument> patientDocument);
        Task<List<PatientLabResultDocument>> GetItemByPatientId(string patientid);
        
    }
}
