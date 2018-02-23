using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class SalarySheetApprove
    {
        [Key]
        [Required]
        public int SalarySheetApproveId { get; set; }

        [Display(Name = "Salary Sheet")]
        public int SalarySheetId { get; set; }

        [ForeignKey("SalarySheetId")]
        public virtual SalarySheet SalarySheet { get; set; }

        [Display(Name = "Approval Employee")]
        public int ApprovalEmployeeInfoId { get; set; }

        [ForeignKey("ApprovalEmployeeInfoId")]
        public virtual EmployeeInfo ApprovalEmployeeInfo { get; set; }

        [Display(Name = "Salary Sheet Status")]
        public int SalarySheetStatusId { get; set; }

        [ForeignKey("SalarySheetStatusId")]
        public virtual SalarySheetStatus SalarySheetStatus { get; set; }

        public bool? IsActive { get; set; }
    }
}