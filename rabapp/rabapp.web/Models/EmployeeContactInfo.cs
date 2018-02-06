using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeContactInfo
    {
        [Key]
        [Required]
        public int EmployeeContactInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Display(Name = "Present Address(House/Flat/Level,Street)")]
        [StringLength(250)]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanant Address(House/Flat/Level,Street)")]
        [StringLength(250)]
        public string PermanantAddress { get; set; }

        [MaxLength(120)]
        [Display(Name = "Post Office")]
        public string PostOfficeName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [MaxLength(120)]
        [Display(Name = "Police Station/Upazila")]
        public string UpazilaName { get; set; }

        [MaxLength(120)]
        [Display(Name = "District")]
        public string DistrictName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Division")]
        public string DivisionName { get; set; }

        [Display(Name = "Email")]
        [StringLength(250)]
        public string EmailAddress { get; set; }

        [StringLength(100)]
        public string PhoneNumber { get; set; }

        [StringLength(10)]
        public string PhoneNumberCode { get; set; }

        public int? PhoneNumberCountryId { get; set; }

        [StringLength(100)]
        public string MobileNumber { get; set; }

        [StringLength(10)]
        public string MobileNumberCode { get; set; }

        public int? MobileNumberCountryId { get; set; }

        [Display(Name = "Resident Type")]
        public int ResidentTypeId { get; set; }

        [ForeignKey("ResidentTypeId")]
        public virtual ResidentType ResidentType { get; set; }
    }
}