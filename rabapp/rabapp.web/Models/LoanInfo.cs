using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class LoanInfo
    {
        [Key]
        [Required]
        public int LoanInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Display(Name = "Issue Date")]
        public DateTime? IssueDate { get; set; }

        [Display(Name = "Loan Amount")]
        public double LoanAmount { get; set; }

        [Display(Name = "Loan Interest")]
        public double LoanInterest { get; set; }

        [Display(Name = "Number of Installment")]
        public double NumberOfInstallment { get; set; }

        [Display(Name = "Installment Amount")]
        public double InstallmentAmount  { get; set; }

        [Display(Name = "Deduction Start Date")]
        public DateTime? DeductionStartDate { get; set; }

        [Display(Name = "Deduction Year")]
        public int? DeductionYear { get; set; }

        [Display(Name = "Deduction Month")]
        public int? DeductionMonth { get; set; }

        [Display(Name = "Check Date")]
        public DateTime? CheckDate { get; set; }

        [Display(Name = "Check No")]
        [MaxLength(120)]
        public string CheckNo { get; set; }

        [Display(Name = "Up To Date")]
        public DateTime? OpeningBalanceUpDate { get; set; }

        [Display(Name = "Opening Balance")]
        [MaxLength(120)]
        public string OpeningBalanceNo { get; set; }

        [Display(Name = "Realized")]
        [MaxLength(120)]
        public string OpeningBalanceRealized { get; set; }

        [Display(Name = "Balance")]
        public double OpeningBalance { get; set; }

        [Display(Name = "Interest")]
        public double OpeningBalanceInterest { get; set; }

        [Display(Name = "Total Amount")]
        public double OpeningBalanceTotalAmount { get; set; }


    }
}