using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.ViewModels
{
    public class PatientFinancialViewModel
    {
        public PatientFinancialViewModel()
        {

        }
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DepartmentId { get; set; }
        public List<Object> PatientContractsOneYear { get; set; }
        public List<Object> PatientContractsOneYearByAppointmentId { get; set; }
        public List<Object> PatientContractsPaymentPlan { get; set; }
        public List<Object> PatientContractsStoredCard { get; set; }
        public List<Object> PatientInsurance { get; set; }
        public List<Object> PatientInsuranceCcmEnrollmentStatus { get; set; }
        public List<Object> PatientEPaymentReceipts { get; set; }
        public List<Object> PatientReferralAuths { get; set; }
        public Object PatientInsuranceBenefitDetails { get; set; }
        public Object PatientEPaymentReceiptsDetails { get; set; }
        public Object PatientClaimsClosed { get; set; }
        public Object PatientClaimsOutstanding { get; set; }
    }
}
