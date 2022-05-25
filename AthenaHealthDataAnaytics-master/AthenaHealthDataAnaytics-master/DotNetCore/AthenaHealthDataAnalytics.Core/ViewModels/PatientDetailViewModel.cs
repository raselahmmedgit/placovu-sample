using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.ViewModels
{
    public class PatientDetailViewModel
    {
        public PatientDetailViewModel()
        {

        }
 
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DepartmentId { get; set; }
        public List<Object> PatientAppointments { get; set; }
        public Object PatientProfile { get; set; }
        public Object PatientPhoto { get; set; }
        public List<Object> PatientCustomFields { get; set; }
        public List<Object> PatientStatements { get; set; }
        public List<Object> PatientAuthorizations { get; set; }
        public Object PatientChartAlert { get; set; }
        public List<Object> PatientInterfaceConsents { get; set; }
        public Object PatientPrivacyInformationVerified { get; set; }
    }
}
