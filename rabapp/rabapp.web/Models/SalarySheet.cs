using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class SalarySheet
    {
        [Key]
        [Required]
        public int SalarySheetId { get; set; }

        [Display(Name = "Salary")]
        public int SalaryInfoId { get; set; }

        [ForeignKey("SalaryInfoId")]
        public virtual SalaryInfo SalaryInfo { get; set; }

        [Display(Name = "From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "From Year")]
        public int? FromYear { get; set; }

        [Display(Name = "To Year")]
        public int? ToYear { get; set; }

        [Display(Name = "From Month")]
        public int? FromMonth { get; set; }

        [Display(Name = "To Month")]
        public int? ToMonth { get; set; }

        [Display(Name = "Salary Sheet Status")]
        public int SalarySheetStatusId { get; set; }

        [ForeignKey("SalarySheetStatusId")]
        public virtual SalarySheetStatus SalarySheetStatus { get; set; }
    }
}