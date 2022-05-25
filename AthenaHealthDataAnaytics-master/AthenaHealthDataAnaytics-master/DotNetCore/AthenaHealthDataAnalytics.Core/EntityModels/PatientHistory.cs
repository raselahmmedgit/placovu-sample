using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.EntityModels
{
    public class PatientHistory
    {
        public PatientHistory()
        {

        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DepartmentId { get; set; }
        public BsonDocument PatientAllergies { get; set; }
        public BsonDocument PatientSocialHistory { get; set; }
        public BsonDocument PatientSurgicalHistory { get; set; }
        public BsonDocument PatientFamilyHistor { get; set; }
        public BsonDocument PatientGynHistory { get; set; }
        public List<BsonDocument> PatientVaccines{ get; set; }
        public List<BsonDocument> PatientVitals  { get; set; }
        public List<BsonDocument> PatientCcda { get; set; }
        public BsonDocument PatientPharmaciesDefault { get; set; }
        public BsonDocument PatientMedications { get; set; }
        public BsonDocument PatientLabsDefault { get; set; }
        public BsonDocument PatientCareTeam { get; set; }

        public List<BsonDocument> PatientPharmaciesPreferred { get; set; }
        public List<BsonDocument> PatientProblems { get; set; }
        public List<BsonDocument> PatientQualityManagement { get; set; }
        public List<BsonDocument> PatientQualityManagementProviders { get; set; }
        public List<BsonDocument> PatientImagingPreferred { get; set; }
        public List<BsonDocument> PatientLabResults { get; set; }
        public List<BsonDocument> PatientAnalytes { get; set; }
        public List<BsonDocument> PatientAdministeredQuestionnaireScreeners { get; set; }
        public string TimeStamp { get; set; }
    }
}
