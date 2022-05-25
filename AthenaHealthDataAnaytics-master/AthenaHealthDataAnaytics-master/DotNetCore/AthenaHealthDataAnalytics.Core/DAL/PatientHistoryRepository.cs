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
    public class PatientHistoryRepository : IPatientHistoryRepository
    {
        private readonly IMongoCollection<PatientHistory> _patientHistorys;
        private static string CollectionName = "PatientHistory";

        public PatientHistoryRepository(IMongoDatabaseSettings mongoDatabaseSettings)
        {
            var database = MongoDBConnectionManager.GetConnection(mongoDatabaseSettings);
            MongoDBConnectionManager.CreateCollection(database, CollectionName);
            _patientHistorys = database.GetCollection<PatientHistory>(CollectionName);
        }
        public async Task InsertItem(PatientHistory patientHistory)
        {
            try
            {
                await _patientHistorys.InsertOneAsync(patientHistory);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<PatientHistory> GetItemByPatientId(string patientid)
        {
            try
            {
                var document = await _patientHistorys.Find(e => e.PatientId == patientid).FirstAsync();
                return document;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
