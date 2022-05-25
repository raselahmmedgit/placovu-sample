using AthenaHealthDataAnalytics.Core.EntityModels;
using MongoDB.Bson;

namespace AthenaHealthDataAnalytics.Core.ViewModels
{
    public class PatientDetailDataViewModel
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DepartmentId { get; set; }
        public PatientDetail PatientDetail { get; set; }
        public PatientEncounter PatientEncounter { get; set; }
        public PatientDocument PatientDocument { get; set; }
        public PatientFinancial PatientFinancial { get; set; }
        public PatientHistory PatientHistory { get; set; }
    }
}