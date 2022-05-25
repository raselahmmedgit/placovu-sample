using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.EntityModels
{
    public class PatientEncounter
    {
        public PatientEncounter()
        {

        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DepartmentId { get; set; }
        public List<BsonDocument> Encounters { get; set; }
        public string TimeStamp { get; set; }

    }
}
