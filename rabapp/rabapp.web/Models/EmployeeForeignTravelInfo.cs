using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeForeignTravelInfo
    {
        [Key]
        [Required]
        public int EmployeeForeignTravelInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [MaxLength(120)]
        [Display(Name = "Title")]
        public string ForeignTravelTitle { get; set; }

        [MaxLength(120)]
        [Display(Name = "Institute")]
        public string InstituteTitle { get; set; }

        [MaxLength(120)]
        [Display(Name = "Grade Position")]
        public string GradePosition { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [Display(Name = "From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime? ToDate { get; set; }
    }
}