using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.EntityModels
{
    public class PatientDetail
    {
        public PatientDetail()
        {

        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DepartmentId { get; set; }
        public List<BsonDocument> PatientAppointments { get; set; }
        public BsonDocument PatientProfile { get; set; }
        public BsonDocument PatientPhoto { get; set; }
        public List<BsonDocument> PatientCustomFields { get; set; }
        public List<BsonDocument> PatientStatements { get; set; }
        public List<BsonDocument> PatientAuthorizations { get; set; }
        public BsonDocument PatientChartAlert { get; set; }
        public List<BsonDocument> PatientInterfaceConsents { get; set; }
        public BsonDocument PatientPrivacyInformationVerified { get; set; }
        public string TimeStamp { get; set; }

    }
}
