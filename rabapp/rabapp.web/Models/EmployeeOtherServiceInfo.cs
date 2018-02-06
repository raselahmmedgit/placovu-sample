using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeOtherServiceInfo
    {
        [Key]
        [Required]
        public int EmployeeOtherServiceInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [MaxLength(120)]
        [Display(Name = "Employer")]
        public string ServiceTitle { get; set; }

        [MaxLength(120)]
        [Display(Name = "Position")]
        public string PositionTitle { get; set; }

        [MaxLength(120)]
        [Display(Name = "Type of Service")]
        public string ServiceTypeTitle { get; set; }

        [Display(Name = "From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime? ToDate { get; set; }
    }
}