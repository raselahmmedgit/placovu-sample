using AthenaHealthDataAnalytics.Core.EntityModels;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.DAL.Interfaces
{
    interface IPatientFinancialRepository
    {
        Task InsertItem(PatientFinancial patientFinancial);
        Task<PatientFinancial> GetItemByPatientId(string patientid);
    }
}
