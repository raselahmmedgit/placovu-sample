using AthenaHealthDataAnalytics.Core.EntityModels;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.DAL.Interfaces
{
    interface IPatientDocumentRepository
    {
        Task InsertItem(PatientDocument patientDocument);
        Task<PatientDocument> GetItemByPatientId(string patientid);
    }
}
