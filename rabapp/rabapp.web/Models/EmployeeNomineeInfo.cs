using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeNomineeInfo
    {
        [Key]
        [Required]
        public int EmployeeNomineeInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [MaxLength(120)]
        [Display(Name = "Name")]
        public string NomineeName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Father Name")]
        public string NomineeFatherName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Mother Name")]
        public string NomineeMotherName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Spouse Name")]
        public string NomineeSpouseName { get; set; }

        [Display(Name = "Phone")]
        [StringLength(100)]
        public string PhoneNumber { get; set; }

        [StringLength(10)]
        public string PhoneNumberCode { get; set; }

        public int? PhoneNumberCountryId { get; set; }

        [Display(Name = "Email")]
        [StringLength(250)]
        public string EmailAddress { get; set; }

        //National ID Number
        [MaxLength(120)]
        [Display(Name = "National ID")]
        public string NationalIDNumber { get; set; }

        //Passport Number
        [MaxLength(120)]
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }
        
        [Display(Name = "Present Address")]
        [StringLength(250)]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanant Address")]
        [StringLength(250)]
        public string PermanantAddress { get; set; }
    }
}