using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.ViewModels
{
    public class PatientHistoryViewModel
    {
        public PatientHistoryViewModel()
        {

        }
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DepartmentId { get; set; }
        public Object PatientAllergies { get; set; }
        public Object PatientSocialHistory { get; set; }
        public Object PatientSurgicalHistory { get; set; }
        public Object PatientFamilyHistor { get; set; }
        public Object PatientGynHistory { get; set; }
        public List<Object> PatientVaccines { get; set; }
        public List<Object> PatientVitals { get; set; }
        public List<Object> PatientCcda { get; set; }
        public Object PatientPharmaciesDefault { get; set; }
        public Object PatientMedications { get; set; }
        public Object PatientLabsDefault { get; set; }
        public Object PatientCareTeam { get; set; }

        public List<Object> PatientPharmaciesPreferred { get; set; }
        public List<Object> PatientProblems { get; set; }
        public List<Object> PatientQualityManagement { get; set; }
        public List<Object> PatientQualityManagementProviders { get; set; }
        public List<Object> PatientImagingPreferred { get; set; }
        public List<Object> PatientLabResults { get; set; }
        public List<Object> PatientAnalytes { get; set; }
        public List<Object> PatientAdministeredQuestionnaireScreeners { get; set; }
    }
}
