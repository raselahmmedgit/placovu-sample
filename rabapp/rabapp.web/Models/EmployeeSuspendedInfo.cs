using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeSuspendedInfo
    {
        [Key]
        [Required]
        public int EmployeeSuspendedInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Attachment")]
        public int? AttachmentFileId { get; set; }

        [ForeignKey("AttachmentFileId")]
        public virtual BaseDocument AttachmentFile { get; set; }

        [Display(Name = "Date")]
        public DateTime? ActionProsecutionDate { get; set; }

        [Display(Name = "Issue Date")]
        public DateTime? IssueDate { get; set; }

        [Display(Name = "From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "Duration")]
        public string DurationDate { get; set; }
    }
}