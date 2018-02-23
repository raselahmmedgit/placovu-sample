
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPersonalSite.EntityModel
{
    [Table("PatientSurveyActivityDetailView")]
    public class PatientSurveyActivityDetailView
    {
        [Key]
        public Guid PatientSurveyDetailId { get; set; }

        public long PracticeProfileId { get; set; }

        public long PatientProfileId { get; set; }

        public long ProcedureId { get; set; }

        public long NotificationId { get; set; }

        public long SurveyQuestionSetId { get; set; }

        public long SurveyQuestionId { get; set; }

        public long? SurveyQuestionDetailId { get; set; }

        public string SurveyQuestionText { get; set; }

        public string QuestionDetailText { get; set; }

        public string DefaultValue { get; set; }

        public Guid PatientProcedureDetailId { get; set; }

        public long PatientNotificationDetailId { get; set; }

        public DateTime SurveySubmitDate { get; set; }

    }
}