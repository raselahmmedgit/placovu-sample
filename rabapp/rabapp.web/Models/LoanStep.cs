using rabapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class LoanStep
    {
        [Key]
        [Required]
        public int LoanStepId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Loan Step")]
        public string LoanStepName { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [Display(Name = "Loan Type")]
        public int LoanTypeId { get; set; }

        [ForeignKey("LoanTypeId")]
        public virtual LoanType LoanType { get; set; }

        [Display(Name = "Loan Step")]
        public int LoanStepOrder { get; set; }

        [Display(Name = "Role")]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}