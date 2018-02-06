using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeGovtServiceInfo
    {
        [Key]
        [Required]
        public int EmployeeGovtServiceInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [MaxLength(120)]
        [Display(Name = "Starting Position")]
        public string StartPositionTitle { get; set; }

        [MaxLength(120)]
        [Display(Name = "Services Sector")]
        public string ServiceSectorName { get; set; }

        [Display(Name = "Date Of Govt Service")]
        public DateTime? GovtServiceDate { get; set; }

        [Display(Name = "Joining Date")]
        public DateTime? JoiningDate { get; set; }
    }
}