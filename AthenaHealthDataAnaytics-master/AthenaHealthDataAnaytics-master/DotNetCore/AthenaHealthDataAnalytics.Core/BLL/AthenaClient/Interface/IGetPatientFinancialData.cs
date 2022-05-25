using System.Collections.Generic;
using System.Json;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AthenaHealthDataAnalytics.Core.BLL.AthenaClient.Interface
{
    public interface IGetPatientFinancialData
    {
        Task<BsonDocument> GetPatientClaimsClosed(string patientid, string departmentid);
        Task<BsonDocument> GetPatientClaimsOutstanding(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientContractsOneYear(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientContractsOneYearByAppointmentId(string patientid, string departmentid,
            string appointmentid);

        Task<List<BsonDocument>> GetPatientContractsPaymentPlan(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientContractsStoredCard(string patientid, string departmentid);
        Task<List<BsonDocument>> GetPatientInsurance(string patientid);
        Task<BsonDocument> GetPatientInsuranceBenefitDetails(string patientid, string insuranceid);
        Task<List<BsonDocument>> GetPatientInsuranceCcmEnrollmentStatus(string patientid, string departmentid,
            string insuranceid);
        Task<List<BsonDocument>> GetPatientEPaymentReceipts(string patientid, string departmentid);
        Task<BsonDocument> GetPatientEPaymentReceiptsDetails(string patientid, string epaymentid);
        Task<List<BsonDocument>> GetPatientReferralAuths(string patientid);
    }
    
    /*
     * not Included
     * GET /patients/{patientid}/receipts/{epaymentid}/signed : returns image or html or pdf
     *  GET /patients/{patientid}/receipts/{epaymentid} : returns image or html or pdf
     *  GET /patients/{patientid}/insurances/{insuranceid}/image : use curl way
     * GET /patients/{patientid}/collectpayment/paymentplan  : {"error": "An internal error has occurred."}
     */
}