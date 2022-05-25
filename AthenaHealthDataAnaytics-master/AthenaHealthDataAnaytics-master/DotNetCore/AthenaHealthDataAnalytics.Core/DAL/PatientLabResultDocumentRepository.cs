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
    public class PatientLabResultDocumentRepository : IPatientLabResultDocumentRepository
    {
        private readonly IMongoCollection<PatientLabResultDocument> _PatientDocuments;
        private static string CollectionName = "PatientLabResultDocument";

        public PatientLabResultDocumentRepository(IMongoDatabaseSettings mongoDatabaseSettings)
        {
            var database = MongoDBConnectionManager.GetConnection(mongoDatabaseSettings);
            MongoDBConnectionManager.CreateCollection(database, CollectionName);
            _PatientDocuments = database.GetCollection<PatientLabResultDocument>(CollectionName);
        }
        public async Task InsertItemCollection(List<PatientLabResultDocument> patientDocument)
        {
            try
            {
                await _PatientDocuments.InsertManyAsync(patientDocument);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<List<PatientLabResultDocument>> GetItemByPatientId(string patientid)
        {
            try
            {
                var document = await _PatientDocuments.Find(e => e.PatientId == patientid).ToListAsync();
                return document;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
