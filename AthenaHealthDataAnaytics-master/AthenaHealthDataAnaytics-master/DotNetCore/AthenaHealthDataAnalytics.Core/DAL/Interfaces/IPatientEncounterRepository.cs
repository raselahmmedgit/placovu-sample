using AthenaHealthDataAnalytics.Core.EntityModels;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.DAL.Interfaces
{
    interface IPatientEncounterRepository
    {
        Task InsertItem(PatientEncounter patientEncounter);
        Task<PatientEncounter> GetItemByPatientId(string patientid);
    }
}
