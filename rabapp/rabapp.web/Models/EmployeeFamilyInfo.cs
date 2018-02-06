using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeFamilyInfo
    {
        [Key]
        [Required]
        public int EmployeeJobInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [MaxLength(120)]
        [Display(Name = "Spouse Name")]
        public string EmployeeSpouseName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Spouse Father Name")]
        public string EmployeeFatherName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Spouse Mother Name")]
        public string EmployeeMotherName { get; set; }

        [StringLength(100)]
        public string PrimaryPhone { get; set; }

        [StringLength(10)]
        public string PrimaryPhoneCode { get; set; }

        public int? PrimaryPhoneCountryId { get; set; }

        [Display(Name = "Occupation")]
        [StringLength(250)]
        public string OccupationName { get; set; }

        [Display(Name = "Organization")]
        [StringLength(250)]
        public string OrganizationName { get; set; }

        [Display(Name = "Present Address")]
        [StringLength(250)]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanant Address")]
        [StringLength(250)]
        public string PermanantAddress { get; set; }
        
    }
}