using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    [Table("EmployeeInfo")]
    public class EmployeeInfo
    {
        [Key]
        [Required]
        public int EmployeeInfoId { get; set; }

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

        [Display(Name = "Gender Type")]
        public int GenderTypeId { get; set; }

        [ForeignKey("GenderTypeId")]
        public virtual GenderType GenderType { get; set; }

        [Display(Name = "Religion Type")]
        public int ReligionTypeId { get; set; }

        [ForeignKey("ReligionTypeId")]
        public virtual ReligionType ReligionType { get; set; }

        [Display(Name = "Blood Group")]
        public int BloodGroupId { get; set; }

        [ForeignKey("BloodGroupId")]
        public virtual BloodGroup BloodGroup { get; set; }

        [Display(Name = "Profile Picture")]
        public int ProfilePictureId { get; set; }

        [ForeignKey("ProfilePictureId")]
        public virtual BaseDocument ProfilePicture { get; set; }

        [Display(Name = "National ID Picture")]
        public int? NationalIdPictureId { get; set; }

        [ForeignKey("NationalIdPictureId")]
        public virtual BaseDocument NationalIdPicture { get; set; }

        //Freedom Fighter
        [Display(Name = "Freedom Fighter")]
        public int? FreedomFighterTypeId { get; set; }

        [ForeignKey("FreedomFighterTypeId")]
        public virtual FreedomFighterType FreedomFighterType { get; set; }

        //Freedom Fighter Relationship
        [Display(Name = "Relationship Of Freedom Fighter")]
        public int? FreedomFighterRelationshipTypeId { get; set; }

        [ForeignKey("FreedomFighterRelationshipTypeId")]
        public virtual FreedomFighterRelationshipType FreedomFighterRelationshipType { get; set; }

        [Display(Name = "Freedom Fighter ID")]
        public int? FreedomFighterId { get; set; }

        //Passport Number
        [MaxLength(120)]
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        public DateTime? PassportExpiryDate { get; set; }

        [Display(Name = "Signature Picture")]
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
        [Display(Name = "Police Verification Status")]
        public bool? IsPoliceVerified { get; set; }

        [Display(Name = "Present Address")]
        [StringLength(250)]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanant Address")]
        [StringLength(250)]
        public string PermanantAddress { get; set; }
    }
}