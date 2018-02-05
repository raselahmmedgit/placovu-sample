using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Required]
        public int EmployeeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Employee ID")]
        public string EmployeeCode { get; set; }

        [MaxLength(120)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Father Name")]
        public string EmployeeFatherName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Mother Name")]
        public string EmployeeMotherName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(100)]
        public string PrimaryPhone { get; set; }

        [StringLength(10)]
        public string PrimaryPhoneCode { get; set; }

        public int? PrimaryPhoneCountryId { get; set; }

        [StringLength(100)]
        public string OtherPhone { get; set; }

        [StringLength(10)]
        public string OtherPhoneCode { get; set; }

        public int? OtherPhoneCountryId { get; set; }

        [StringLength(250)]
        public string EmailAddress { get; set; }

        [Display(Name = "District")]
        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        [Display(Name = "GenderType")]
        public int GenderTypeId { get; set; }

        [ForeignKey("GenderTypeId")]
        public virtual GenderType GenderType { get; set; }

        [Display(Name = "ReligionType")]
        public int ReligionTypeId { get; set; }

        [ForeignKey("ReligionTypeId")]
        public virtual ReligionType ReligionType { get; set; }

        [Display(Name = "BloodGroup")]
        public int BloodGroupId { get; set; }

        [ForeignKey("BloodGroupId")]
        public virtual BloodGroup BloodGroup { get; set; }

        [Display(Name = "ProfilePicture")]
        public int ProfilePictureId { get; set; }

        [ForeignKey("ProfilePictureId")]
        public virtual BaseDocument ProfilePicture { get; set; }

        [Display(Name = "NationalIdPicture")]
        public int? NationalIdPictureId { get; set; }

        [ForeignKey("NationalIdPictureId")]
        public virtual BaseDocument NationalIdPicture { get; set; }

        //Freedom Fighter
        [Display(Name = "FreedomFighterType")]
        public int? FreedomFighterTypeId { get; set; }

        [ForeignKey("FreedomFighterTypeId")]
        public virtual FreedomFighterType FreedomFighterType { get; set; }

        //Passport Number
        [MaxLength(120)]
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        public DateTime? PassportExpiryDate { get; set; }

        [Display(Name = "SignaturePicture")]
        public int? SignaturePictureId { get; set; }

        [ForeignKey("SignaturePictureId")]
        public virtual BaseDocument SignaturePicture { get; set; }

        //Birth Certificate Number
        [MaxLength(120)]
        [Display(Name = "Birth Certificate Number")]
        public string BirthCertificateNumber { get; set; }

        [Display(Name = "Last Day Working")]
        public int? LastDayWork { get; set; }

        //Police Verification Status
        public bool? IsPoliceVerified { get; set; }

        [Display(Name = "Present Address")]
        [StringLength(250)]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanant Address")]
        [StringLength(250)]
        public string PermanantAddress { get; set; }
    }
}