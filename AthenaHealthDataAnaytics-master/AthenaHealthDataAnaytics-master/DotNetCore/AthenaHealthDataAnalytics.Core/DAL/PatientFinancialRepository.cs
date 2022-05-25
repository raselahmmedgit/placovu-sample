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
    public class PatientFinancialRepository : IPatientFinancialRepository
    {
        private readonly IMongoCollection<PatientFinancial> _patientFinancials;
        private static string CollectionName = "PatientFinancial";

        public PatientFinancialRepository(IMongoDatabaseSettings mongoDatabaseSettings)
        {
            var database = MongoDBConnectionManager.GetConnection(mongoDatabaseSettings);
            MongoDBConnectionManager.CreateCollection(database, CollectionName);
            _patientFinancials = database.GetCollection<PatientFinancial>(CollectionName);
        }
        public async Task InsertItem(PatientFinancial patientFinancial)
        {
            try
            {
                await _patientFinancials.InsertOneAsync(patientFinancial);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<PatientFinancial> GetItemByPatientId(string patientid)
        {
            try
            {
                var document = await _patientFinancials.Find(e => e.PatientId == patientid).FirstAsync();
                return document;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
