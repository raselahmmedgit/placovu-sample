using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaHealthDataAnalytics.Core.EntityModels
{
    public class AthenaHealthPatient
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("departmentid")]
        public string DepartmentId { get; set; }

        [JsonProperty("primaryproviderid")]
        public int PrimaryProviderId { get; set; }


        [JsonProperty("portalaccessgiven")]
        public bool PortalAccessGiven { get; set; }

        [JsonProperty("driverslicense")]
        public bool DriversLicense { get; set; }

        [JsonProperty("contactpreference_appointment_email")]
        public bool ContactPreferenceAppointmentEmail { get; set; }

        [JsonProperty("contactpreference_appointment_sms")]
        public bool ContactPreferenceAppointmentSms { get; set; }

        [JsonProperty("contactpreference_billing_phone")]
        public bool ContactPreferenceBillingPhone { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("contactpreference_announcement_phone")]
        public bool ContactPreferenceAnnouncementPhone { get; set; }

        [JsonProperty("contactpreference_lab_sms")]
        public bool ContactPreferenceLabSms { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("guarantoraddresssameaspatient")]
        public bool GuarantorAddressSameAsPatient { get; set; }

        [JsonProperty("portaltermsonfile")]
        public bool PortalTermsOnFile { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("privacyinformationverified")]
        public bool PrivacyInformationVerified { get; set; }

        [JsonProperty("primarydepartmentid")]
        public string PrimaryDepartmentId { get; set; }

        [JsonProperty("contactpreference_lab_email")]
        public bool ContactPreferenceLabEmail { get; set; }

        [JsonProperty("contactpreference_announcement_sms")]
        public bool ContactPreferenceAnnouncementSms { get; set; }

        [JsonProperty("emailexists")]
        public bool EmailExists { get; set; }

        [JsonProperty("patientphoto")]
        public bool PatientPhoto { get; set; }

        [JsonProperty("contactpreference_billing_email")]
        public bool ContactPreferenceBillingEmail { get; set; }

        [JsonProperty("contactpreference_announcement_email")]
        public bool ContactPreferenceAnnouncementEmail { get; set; }

        [JsonProperty("registrationdate")]
        public string RegistrationDate { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("guarantorcountrycode")]
        public string GuarantorCountryCode { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("contactpreference_appointment_phone")]
        public bool ContactPreferenceAppointmentPhone { get; set; }

        [JsonProperty("patientid")]
        public string PatientId { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("mobilephone")]
        public string MobilePhone { get; set; }
        [JsonProperty("homephone")]
        public string HomePhone { get; set; }


        [JsonProperty("guarantorrelationshiptopatient")]
        public string GuarantorRelationshipToPatient { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("contactpreference_billing_sms")]
        public bool ContactPreferenceBillingSms { get; set; }

        [JsonProperty("countrycode")]
        public string CountryCode { get; set; }

        [JsonProperty("consenttotext")]
        public bool ConsentToText { get; set; }

        [JsonProperty("countrycode3166")]
        public string CountryCode3166 { get; set; }

        [JsonProperty("contactpreference_lab_phone")]
        public bool ContactPreferenceLabPhone { get; set; }

        [JsonProperty("guarantorcountrycode3166")]
        public string GuarantorCountryCode3166 { get; set; }
    }
}
