using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeAwardHonorInfo
    {
        [Key]
        [Required]
        public int EmployeeAwardHonorInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [MaxLength(120)]
        [Display(Name = "Award/Honor Title")]
        public string AwardHonorTitle { get; set; }

        [MaxLength(120)]
        [Display(Name = "Organization")]
        public string OrganizationName { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [Display(Name = "Receive Date")]
        public DateTime AwardHonorReceiveDate { get; set; }
    }
}