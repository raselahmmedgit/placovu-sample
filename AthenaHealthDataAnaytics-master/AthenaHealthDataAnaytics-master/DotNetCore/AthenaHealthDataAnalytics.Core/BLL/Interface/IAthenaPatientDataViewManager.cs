using AthenaHealthDataAnalytics.Core.EntityModels;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.BLL.Interface
{
    public interface IAthenaPatientDataViewManager
    {
        Task<List<PatientDetail>> GetPatientDetail();
        Task<PatientDetail> GetPatientDetailByPatientId(string PatientId);
        Task<PatientEncounter>  GetPatientEncounterByPatientId(string patientId);
        Task<PatientHistory> GetPatienHistoricalByPatientId(string patientId);
        Task<PatientFinancial> GetPatientFinancialByPatientId(string patientId);
        Task<PatientDocument> GetPatientDocumentByPatientId(string patientId);
        Task<DataTablesResponse> GetPatientDetailForDataTablesResponseAsync(IDataTablesRequest request);
    }
}
