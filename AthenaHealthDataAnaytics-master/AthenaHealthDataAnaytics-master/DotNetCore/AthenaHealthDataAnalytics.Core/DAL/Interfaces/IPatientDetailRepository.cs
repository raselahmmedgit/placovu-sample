using AthenaHealthDataAnalytics.Core.BLL;
using AthenaHealthDataAnalytics.Core.EntityModels;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.DAL.Interfaces
{
    interface IPatientDetailRepository
    {
        Task InsertItem(PatientDetail patientDetail);
        Task<PatientDetail> GetItemByPatientId(string patientid);
        Task<List<PatientDetail>> GetPatientDetail();
    }
}
