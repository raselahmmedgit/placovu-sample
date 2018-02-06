using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeTransferInfo
    {
        [Key]
        [Required]
        public int EmployeeTransferInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Section")]
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [Display(Name = "Issue Date")]
        public DateTime? IssueDate { get; set; }

        [Display(Name = "From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "Duration")]
        public string DurationDate { get; set; }

        [MaxLength(120)]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}