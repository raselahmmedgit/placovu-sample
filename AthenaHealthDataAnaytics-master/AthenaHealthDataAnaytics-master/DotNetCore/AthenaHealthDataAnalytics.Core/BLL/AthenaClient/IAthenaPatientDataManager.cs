using System.Threading.Tasks;
using AthenaHealthDataAnalytics.Core.ViewModels;

namespace BLL.AthenaClient
{
    public interface IAthenaPatientDataManager
    {
        Task InsertAthenaPatientDetailToMongoDB(string patientId, string departmentId);
        Task InsertAthenaPatientDocumentDataToMongoDB(string patientId, string departmentId);
        Task InsertAthenaEncounterDataToMongoDB(string patientId, string departmentId);
        Task InsertAthenaPatientFinancialToMongoDB(string patientId, string departmentId);
        Task InsertAthenaPatientHistoryToMongoDB(string patientId, string departmentId);
        Task<PatientDetailDataViewModel> GetAthenaPatientDataFromMongoDB(string patientId, string departmentId);
        
    }
}