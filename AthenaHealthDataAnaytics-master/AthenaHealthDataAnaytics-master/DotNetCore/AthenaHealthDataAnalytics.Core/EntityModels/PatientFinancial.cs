using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.EntityModels
{
    public class PatientFinancial
    {
        public PatientFinancial()
        {

        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DepartmentId { get; set; }
        public List<BsonDocument> PatientContractsOneYear { get; set; }
        public List<BsonDocument> PatientContractsOneYearByAppointmentId { get; set; }
        public List<BsonDocument> PatientContractsPaymentPlan { get; set; }
        public List<BsonDocument> PatientContractsStoredCard { get; set; }
        public List<BsonDocument> PatientInsurance { get; set; }
        public List<BsonDocument> PatientInsuranceCcmEnrollmentStatus { get; set; }
        public List<BsonDocument> PatientEPaymentReceipts { get; set; }
        public List<BsonDocument> PatientReferralAuths { get; set; }
        public BsonDocument PatientInsuranceBenefitDetails { get; set; }
        public BsonDocument PatientEPaymentReceiptsDetails { get; set; }
        public BsonDocument PatientClaimsClosed { get; set; }
        public BsonDocument PatientClaimsOutstanding { get; set; }
        public string TimeStamp { get; set; }

    }
}
