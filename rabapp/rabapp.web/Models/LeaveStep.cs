using rabapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class LeaveStep
    {
        [Key]
        [Required]
        public int LeaveStepId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Leave Step")]
        public string LeaveStepName { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType LeaveType { get; set; }

        [Display(Name = "Leave Step")]
        public int LeaveStepOrder { get; set; }

        [Display(Name = "Role")]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}