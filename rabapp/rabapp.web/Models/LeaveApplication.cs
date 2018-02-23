using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class LeaveApplication
    {
        [Key]
        [Required]
        public int LeaveApplicationId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType LeaveType { get; set; }

        [Display(Name = "Leave Status")]
        public int LeaveStatusId { get; set; }

        [ForeignKey("LeaveStatusId")]
        public virtual LeaveStatus LeaveStatus { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Duration")]
        public string DurationDate { get; set; }

        [MaxLength(256)]
        [Display(Name = "Leave Reason")]
        public string LeaveReason { get; set; }

        [Display(Name = "Attachment")]
        public int? AttachmentFileId { get; set; }

        [ForeignKey("AttachmentFileId")]
        public virtual BaseDocument AttachmentFile { get; set; }
        
    }
}