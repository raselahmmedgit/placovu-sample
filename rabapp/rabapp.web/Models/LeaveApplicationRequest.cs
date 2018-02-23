using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class LeaveApplicationRequest
    {
        [Key]
        [Required]
        public int LeaveApplicationRequestId { get; set; }

        [Display(Name = "Approval Employee")]
        public int ApprovalEmployeeInfoId { get; set; }

        [ForeignKey("ApprovalEmployeeInfoId")]
        public virtual EmployeeInfo ApprovalEmployeeInfo { get; set; }

        [Display(Name = "Leave Status")]
        public int LeaveStatusId { get; set; }

        [ForeignKey("LeaveStatusId")]
        public virtual LeaveStatus LeaveStatus { get; set; }

        public bool? IsActive { get; set; }
    }
}