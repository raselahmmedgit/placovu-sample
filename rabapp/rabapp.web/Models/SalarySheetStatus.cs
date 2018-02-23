using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class SalarySheetStatus
    {
        [Key]
        [Required]
        public int SalarySheetStatusId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Salary Sheet Status")]
        public string SalarySheetStatusName { get; set; }
    }
}