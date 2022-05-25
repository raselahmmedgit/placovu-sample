using AthenaHealthDataAnalytics.Core.BLL.MongoDBClient;
using AthenaHealthDataAnalytics.Core.DAL.Interfaces;
using AthenaHealthDataAnalytics.Core.EntityModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AthenaHealthDataAnalytics.Core.DAL
{
    public class PatientEncounterRepository : IPatientEncounterRepository
    {
        private readonly IMongoCollection<PatientEncounter> _patientEncounters;
        private static string CollectionName = "PatientEncounter";

        public PatientEncounterRepository(IMongoDatabaseSettings mongoDatabaseSettings)
        {
            var database = MongoDBConnectionManager.GetConnection(mongoDatabaseSettings);
            MongoDBConnectionManager.CreateCollection(database, CollectionName);
            _patientEncounters = database.GetCollection<PatientEncounter>(CollectionName);
        }
        public async Task InsertItem(PatientEncounter patientEncounter)
        {
            try
            {
                await _patientEncounters.InsertOneAsync(patientEncounter);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<PatientEncounter> GetItemByPatientId(string patientid)
        {
            try
            {
                var document = await _patientEncounters.Find(e => e.PatientId == patientid).FirstAsync();
                return document;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
