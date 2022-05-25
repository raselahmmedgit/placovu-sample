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
    public class PatientDocumentRepository : IPatientDocumentRepository
    {
        private readonly IMongoCollection<PatientDocument> _PatientDocuments;
        private static string CollectionName = "PatientDocument";

        public PatientDocumentRepository(IMongoDatabaseSettings mongoDatabaseSettings)
        {
            var database = MongoDBConnectionManager.GetConnection(mongoDatabaseSettings);
            MongoDBConnectionManager.CreateCollection(database, CollectionName);
            _PatientDocuments = database.GetCollection<PatientDocument>(CollectionName);
        }
        public async Task InsertItem(PatientDocument patientDocument)
        {
            try
            {
                await _PatientDocuments.InsertOneAsync(patientDocument);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<PatientDocument> GetItemByPatientId(string patientid)
        {
            try
            {
                var document = await _PatientDocuments.Find(e => e.PatientId == patientid).FirstAsync();
                return document;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
