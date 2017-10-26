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
}