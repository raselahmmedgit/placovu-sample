using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeReferenceInfo
    {
        [Key]
        [Required]
        public int EmployeeReferenceInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [MaxLength(120)]
        [Display(Name = "Name")]
        public string ReferenceName { get; set; }

        [Display(Name = "Address")]
        [StringLength(250)]
        public string ReferenceAddress { get; set; }

        [MaxLength(120)]
        [Display(Name = "Designation")]
        public string DesignationTitle { get; set; }

        [MaxLength(120)]
        [Display(Name = "Organization")]
        public string OrganizationName { get; set; }

        [Display(Name = "Email")]
        [StringLength(250)]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone")]
        [StringLength(100)]
        public string PhoneNumber { get; set; }

        [StringLength(10)]
        public string PhoneNumberCode { get; set; }

        public int? PhoneNumberCountryId { get; set; }

        [Display(Name = "Mobile")]
        [StringLength(100)]
        public string MobileNumber { get; set; }

        [StringLength(10)]
        public string MobileNumberCode { get; set; }

        public int? MobileNumberCountryId { get; set; }

    }
}