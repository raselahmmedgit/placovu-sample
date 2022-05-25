using AthenaHealthDataAnalytics.Core.EntityModels;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.DAL.Interfaces
{
    interface IPatientHistoryRepository
    {
        Task InsertItem(PatientHistory patientHistory);
        Task<PatientHistory> GetItemByPatientId(string patientid);
    }
}
