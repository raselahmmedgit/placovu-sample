using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab.SurgicalConciergeApp.Models
{
    public class Procedure
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int ProcedureId { get; set; }

        public string Name { get; set; }
    }
    public class PatientProfile
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int PatientProfileId { get; set; }

        public string Name { get; set; }
    }
    public class WorkFlowCategory
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int WorkFlowCategoryId { get; set; }

        public string Name { get; set; }
    }
    public class WorkFlow
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int WorkFlowId { get; set; }

        public string Name { get; set; }

        public int WorkFlowCategoryId { get; set; }
        [ForeignKey("WorkFlowCategoryId")]
        public virtual WorkFlowCategory WorkFlowCategory { get; set; }
    }
    public class WorkFlowProcedure
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int WorkFlowProcedureId { get; set; }

        public int WorkFlowId { get; set; }
        [ForeignKey("WorkFlowId")]
        public virtual WorkFlow WorkFlow { get; set; }

        public int ProcedureId { get; set; }
        [ForeignKey("ProcedureId")]
        public virtual Procedure Procedure { get; set; }
    }
    public class WorkFlowPatientProfile
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int WorkFlowPatientProfileId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public bool? HasStart { get; set; }

        public bool? HasEnd { get; set; }

        public bool? IsActive { get; set; }

        public int WorkFlowId { get; set; }
        [ForeignKey("WorkFlowId")]
        public virtual WorkFlow WorkFlow { get; set; }

        public int PatientProfileId { get; set; }
        [ForeignKey("PatientProfileId")]
        public virtual PatientProfile PatientProfile { get; set; }
    }

    #region Baby Boomers

    public class BabyBoomerProfile
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public Guid BabyBoomerProfileId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }

    public class BabyBoomerAttendeeProfileType
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public Guid AttendeeProfileTypeId { get; set; }

        public string Name { get; set; }
    }

    public class BabyBoomerAttendeeProfile
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public Guid AttendeeProfileId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }

    public class BabyBoomerActivityType
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public Guid ActivityTypeId { get; set; }

        public string Name { get; set; }
    }
    public class BabyBoomerActivity
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public Guid ActivityId { get; set; }

        public string Name { get; set; }

        public Guid ActivityTypeId { get; set; }
        [ForeignKey("ActivityTypeId")]
        public virtual BabyBoomerActivityType BabyBoomerActivityType { get; set; }
    }
    
    public class BabyBoomerActivityDetail
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public Guid ActivityDetailId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public bool? HasStart { get; set; }

        public bool? HasEnd { get; set; }

        public bool? IsActive { get; set; }

        public Guid ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public virtual BabyBoomerActivity BabyBoomerActivity { get; set; }

        public Guid BabyBoomerProfileId { get; set; }
        [ForeignKey("BabyBoomerProfileId")]
        public virtual BabyBoomerProfile BabyBoomerProfile { get; set; }
    }

    #endregion
}