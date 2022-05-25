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
    public class PatientDetailRepository : IPatientDetailRepository
    {
        private readonly IMongoCollection<PatientDetail> _PatientDetails;
        private static string CollectionName = "PatientDetail";
        public PatientDetailRepository(IMongoDatabaseSettings mongoDatabaseSettings)
        {
            var database = MongoDBConnectionManager.GetConnection(mongoDatabaseSettings);
            MongoDBConnectionManager.CreateCollection(database, CollectionName) ;
            _PatientDetails = database.GetCollection<PatientDetail>(CollectionName);
        }
        public async Task InsertItem(PatientDetail patientDetail)
        {
            try
            {
                await _PatientDetails.InsertOneAsync(patientDetail);
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        public async Task<PatientDetail> GetItemByPatientId(string patientid)
        {
            try
            {
                var document = await _PatientDetails.Find(e=>e.PatientId==patientid).FirstAsync();
                return document;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<List<PatientDetail>> GetPatientDetail()
        {
            try
            {
                var documents = await _PatientDetails.Find(_ => true).ToListAsync();
                return documents;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
