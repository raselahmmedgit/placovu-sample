namespace MyPersonalSite.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //PatientSurveyActivityExcelViewModel
    public partial class PatientSurveyActivityView
    {
        [Key]
        public  Guid AutoId { get; set; }
        public long PatientProfileId { get; set; }

        public long ProcedureId { get; set; }

        [StringLength(256)]
        public string SurveyQuestionSetName { get; set; }

        //public bool HasSubmited { get; set; }

        public DateTime? NotificationDate { get; set; }

        [StringLength(250)]
        public string PreferredName { get; set; }

        [StringLength(250)]
        public string ProcedureName { get; set; }

        [StringLength(250)]
        public string EmailAddress { get; set; }

        [StringLength(250)]
        public string PrimaryPhone { get; set; }

        public string NotificationTitle { get; set; }

        public string LogInTimeUtc { get; set; }
        public string HasSubmited { get; set; }

        public DateTime? LastLogInTimeUtc { get; set; }

        public string SubmitDate { get; set; }
    }
}