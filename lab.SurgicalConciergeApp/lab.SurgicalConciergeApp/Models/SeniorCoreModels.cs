using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab.SurgicalConciergeApp.Models
{
    public class BaseEntityModel : IBaseEntityModel
    {
        public bool IsArchived { get; set; }
    }

    public interface IBaseEntityModel
    {
        bool IsArchived { get; set; }
    }

    public interface IChangeTrackerEntityModel
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }

    public class ChangeTrackerEntityModel : IChangeTrackerEntityModel
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }

    public interface IDeleteTrackerEntityModel
    {
        bool IsDeleted { get; set; }
        string DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }

    public class DeleteTrackerEntityModel : IDeleteTrackerEntityModel
    {
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    [Table("AspNetUser")]
    public class AspNetUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public int BusinessUnitId { get; set; }
        public string BusinessUnitName { get; set; }
        public int CompanyId { get; set; }
        public bool IsSystemAdmin { get; set; }

    }

    [Table("SysOrganization")]
    public class SysOrganization
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrganizationId { get; set; }

        [StringLength(250)]
        public string OrganizationName { get; set; }

        public int? OrganizationTypeId { get; set; }
        [ForeignKey("OrganizationTypeId")]
        public virtual OrganizationType OrganizationType { get; set; }
    }

    [Table("OrganizationType")]
    public class OrganizationType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }

    [Table("BaseAddress")]
    public class BaseAddress
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddressId { get; set; }

        [StringLength(100)]
        public string EmailAddress { get; set; }

        [StringLength(450)]
        public string StreetAddress { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(128)]
        public string CityName { get; set; }

        public int? StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual BaseState BaseState { get; set; }

        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual BaseCountry BaseCountry { get; set; }

        [StringLength(128)]
        public string WebsiteAddress { get; set; }

        [StringLength(50)]
        public string OfficePhone { get; set; }

        [StringLength(10)]
        public string OfficePhoneCode { get; set; }

        public int? OfficePhoneCountryId { get; set; }
        [ForeignKey("OfficePhoneCountryId")]
        public virtual BaseCountry OfficePhoneCountry { get; set; }

        [StringLength(20)]
        public string PrimaryPhone { get; set; }

        [StringLength(10)]
        public string PrimaryPhoneCode { get; set; }

        public int? PrimaryPhoneCountryId { get; set; }
        [ForeignKey("PrimaryPhoneCountryId")]
        public virtual BaseCountry PrimaryPhoneCountry { get; set; }

        [StringLength(20)]
        public string OtherPhone { get; set; }

        [StringLength(10)]
        public string OtherPhoneCode { get; set; }

        public int? OtherPhoneCountryId { get; set; }
        [ForeignKey("OtherPhoneCountryId")]
        public virtual BaseCountry OtherPhoneCountry { get; set; }
    }

    [Table("CompanyProfile")]
    public class CompanyProfile : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CompanyId { get; set; }

        public Guid? OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual SysOrganization SysOrganization { get; set; }

        [StringLength(250)]
        public string CompanyName { get; set; }

        [StringLength(128)]
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AspNetUser AspNetUser { get; set; }

        public Guid? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual BaseAddress BaseAddress { get; set; }

        [StringLength(128)]
        public string EmailAddress { get; set; }

        [StringLength(128)]
        public string AdminEmailAddress { get; set; }

        [StringLength(128)]
        public string AdminPassword { get; set; }

        [StringLength(128)]
        public string AdminName { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion

    }

    [Table("CompanyProfilePicture")]
    public class CompanyProfilePicture : IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CompanyProfilePictureId { get; set; }

        public Guid CompanyProfileId { get; set; }
        [ForeignKey("CompanyProfileId")]
        public virtual CompanyProfile CompanyProfile { get; set; }

        public Guid PictureId { get; set; }
        [ForeignKey("PictureId")]
        public virtual BasePicture BasePicture { get; set; }

        #region Delete Model
        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }

    [Table("LocationType")]
    public class LocationType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }
    
    [Table("BaseState")]
    public class BaseState : IBaseEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }

        [Required]
        [StringLength(150)]
        public string StateName { get; set; }

        [StringLength(10)]
        public string StateShortName { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        #region Base Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }

    [Table("BaseCountry")]
    public class BaseCountry : IBaseEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        [StringLength(128)]
        public string CountryName { get; set; }

        [StringLength(128)]
        public string CountryDisplayName { get; set; }

        [StringLength(5)]
        public string CountryIso { get; set; }

        [StringLength(5)]
        public string CountryIso3 { get; set; }

        [StringLength(8)]
        public string NumberCode { get; set; }

        [StringLength(8)]
        public string PhoneCode { get; set; }

        public bool IsPublished { get; set; }

        #region Base Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }

    [Table("DocumentType")]
    public class DocumentType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }

    [Table("BaseDocument")]
    public class BaseDocument : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DocumentId { get; set; }

        public int DocumentTypeId { get; set; }
        [ForeignKey("DocumentTypeId")]
        public virtual DocumentType DocumentType { get; set; }

        [StringLength(250)]
        public string DocumentName { get; set; }

        [StringLength(250)]
        public string DocumentPath { get; set; }

        [StringLength(50)]
        public string DocumentContentType { get; set; }

        public int? DocumentLength { get; set; }

        public byte[] DocumentContent { get; set; }

        public DateTime? DocumentUploadDate { get; set; }

        public bool? IsTemporaryDocument { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }

    [Table("PictureType")]
    public class PictureType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }

    [Table("BasePicture")]
    public class BasePicture : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PictureId { get; set; }

        public int PictureTypeId { get; set; }
        [ForeignKey("PictureTypeId")]
        public virtual PictureType PictureType { get; set; }

        [StringLength(450)]
        public string MimeType { get; set; }

        [StringLength(450)]
        public string SeoFilename { get; set; }

        public string AltAttribute { get; set; }

        public string TitleAttribute { get; set; }

        public string VirtualPath { get; set; }

        public bool IsNew { get; set; }

        public bool? IsTemporaryPicture { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }

    [Table("TemplateType")]
    public class TemplateType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }

    [Table("BaseTemplate")]
    public class BaseTemplate : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TemplateId { get; set; }

        public int TemplateTypeId { get; set; }
        [ForeignKey("TemplateTypeId")]
        public virtual TemplateType TemplateType { get; set; }

        [Required]
        [StringLength(500)]
        public string TemplateTitle { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string TemplateDetail { get; set; }

        [StringLength(500)]
        public string TemplateParam { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion

    }

    [Table("SchedulerProfile")]
    public class SchedulerProfile : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProfileId { get; set; }

        public Guid? CompanyProfileId { get; set; }
        [ForeignKey("CompanyProfileId")]
        public virtual CompanyProfile CompanyProfile { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string PreferredName { get; set; }

        public Guid? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual BaseAddress BaseAddress { get; set; }

        [StringLength(128)]
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AspNetUser AspNetUser { get; set; }

        [StringLength(50)]
        public string PrimaryPassword { get; set; }

        public bool IsDeactivated { get; set; }

        public Guid ProfilePictureId { get; set; }
        [ForeignKey("ProfilePictureId")]
        public virtual BasePicture ProfilePicture { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }

    [Table("NurseProfile")]
    public class NurseProfile : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProfileId { get; set; }

        public Guid? CompanyProfileId { get; set; }
        [ForeignKey("CompanyProfileId")]
        public virtual CompanyProfile CompanyProfile { get; set; }
        
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string PreferredName { get; set; }

        public Guid? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual BaseAddress BaseAddress { get; set; }

        [StringLength(128)]
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AspNetUser AspNetUser { get; set; }

        [StringLength(50)]
        public string PrimaryPassword { get; set; }
                
        public bool IsDeactivated { get; set; }

        public Guid ProfilePictureId { get; set; }
        [ForeignKey("ProfilePictureId")]
        public virtual BasePicture ProfilePicture { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }

    [Table("ProfessionalProfile")]
    public class ProfessionalProfile : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProfileId { get; set; }

        public Guid? CompanyProfileId { get; set; }
        [ForeignKey("CompanyProfileId")]
        public virtual CompanyProfile CompanyProfile { get; set; }
        
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string PreferredName { get; set; }

        public Guid? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual BaseAddress BaseAddress { get; set; }

        [StringLength(128)]
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AspNetUser AspNetUser { get; set; }

        [StringLength(50)]
        public string PrimaryPassword { get; set; }

        public bool IsDeactivated { get; set; }

        public Guid ProfilePictureId { get; set; }
        [ForeignKey("ProfilePictureId")]
        public virtual BasePicture ProfilePicture { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }

    [Table("GuestProfile")]
    public class GuestProfile : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProfileId { get; set; }

        public Guid? CompanyProfileId { get; set; }
        [ForeignKey("CompanyProfileId")]
        public virtual CompanyProfile CompanyProfile { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string PreferredName { get; set; }

        public Guid? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual BaseAddress BaseAddress { get; set; }

        [StringLength(128)]
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AspNetUser AspNetUser { get; set; }

        [StringLength(50)]
        public string PrimaryPassword { get; set; }

        public bool IsDeactivated { get; set; }

        public Guid ProfilePictureId { get; set; }
        [ForeignKey("ProfilePictureId")]
        public virtual BasePicture ProfilePicture { get; set; }

        public bool EmailAllowed { get; set; }

        public bool SmsAllowed { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? DateOfBirth { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }
    
    [Table("RelationType")]
    public class RelationType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }

    [Table("GuestRelativesProfile")]
    public class GuestRelativesProfile : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProfileId { get; set; }

        public Guid? CompanyProfileId { get; set; }
        [ForeignKey("CompanyProfileId")]
        public virtual CompanyProfile CompanyProfile { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string PreferredName { get; set; }

        public Guid? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual BaseAddress BaseAddress { get; set; }

        [StringLength(128)]
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AspNetUser AspNetUser { get; set; }

        [StringLength(50)]
        public string PrimaryPassword { get; set; }

        public bool IsDeactivated { get; set; }

        public Guid ProfilePictureId { get; set; }
        [ForeignKey("ProfilePictureId")]
        public virtual BasePicture ProfilePicture { get; set; }

        public int? RelationTypeId { get; set; }
        [ForeignKey("RelationTypeId")]
        public virtual RelationType RelationType { get; set; }

        public bool EmailAllowed { get; set; }

        public bool SmsAllowed { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }
    
    [Table("EmailPriorityType")]
    public class EmailPriorityType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }

    [Table("EmailNotificationType")]
    public class EmailNotificationType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }

    [Table("EmailStatus")]
    public class EmailStatus
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }

        public string StatusName { get; set; }
    }

    [Table("GuestEmailHistory")]
    public class GuestEmailHistory : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmailHistoryId { get; set; }

        public Guid? GuestProfileId { get; set; }
        [ForeignKey("GuestProfileId")]
        public virtual GuestProfile GuestProfile { get; set; }

        [StringLength(200)]
        public string GuestProfileName { get; set; }

        public Guid? CompanyProfileId { get; set; }
        [ForeignKey("CompanyProfileId")]
        public virtual CompanyProfile CompanyProfile { get; set; }

        [StringLength(200)]
        public string CompanyProfileName { get; set; }

        public Guid? ProfessionalProfileId { get; set; }
        [ForeignKey("ProfessionalProfileId")]
        public virtual ProfessionalProfile ProfessionalProfile { get; set; }

        [StringLength(200)]
        public string ProfessionalProfileName { get; set; }

        public Guid? GuestRelativesProfileId { get; set; }
        [ForeignKey("GuestRelativesProfileId")]
        public virtual GuestRelativesProfile GuestRelativesProfile { get; set; }

        [StringLength(200)]
        public string GuestRelativesProfileName { get; set; }

        public Guid? TemplateId { get; set; }
        [ForeignKey("TemplateId")]
        public virtual BaseTemplate BaseTemplate { get; set; }

        [Column(TypeName = "text")]
        public string TemplateTitle { get; set; }

        [Column(TypeName = "text")]
        public string TemplateDetail { get; set; }

        [StringLength(200)]
        public string ReceiverEmailAddress { get; set; }

        [StringLength(50)]
        public string OfficePhone { get; set; }

        [StringLength(200)]
        public string StreetAddress { get; set; }

        [StringLength(200)]
        public string LocationName { get; set; }

        public int? EmailStatusId { get; set; }
        [ForeignKey("EmailStatusId")]
        public virtual EmailStatus EmailStatus { get; set; }

        public int? FailedCount { get; set; }

        [Column(TypeName = "text")]
        public string ErrorMessage { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }

    [Table("SmsStatus")]
    public class SmsStatus
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }

        public string StatusName { get; set; }
    }

    [Table("GuestSmsHistory")]
    public class GuestSmsHistory : IBaseEntityModel, IChangeTrackerEntityModel, IDeleteTrackerEntityModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SmsHistoryId { get; set; }


        public Guid? GuestProfileId { get; set; }
        [ForeignKey("GuestProfileId")]
        public virtual GuestProfile GuestProfile { get; set; }

        [StringLength(200)]
        public string GuestProfileName { get; set; }

        public Guid? CompanyProfileId { get; set; }
        [ForeignKey("CompanyProfileId")]
        public virtual CompanyProfile CompanyProfile { get; set; }

        [StringLength(200)]
        public string CompanyProfileName { get; set; }

        public Guid? ProfessionalProfileId { get; set; }
        [ForeignKey("ProfessionalProfileId")]
        public virtual ProfessionalProfile ProfessionalProfile { get; set; }

        [StringLength(200)]
        public string ProfessionalProfileName { get; set; }

        public Guid? GuestRelativesProfileId { get; set; }
        [ForeignKey("GuestRelativesProfileId")]
        public virtual GuestRelativesProfile GuestRelativesProfile { get; set; }

        [StringLength(200)]
        public string GuestRelativesProfileName { get; set; }

        public Guid? TemplateId { get; set; }
        [ForeignKey("TemplateId")]
        public virtual BaseTemplate BaseTemplate { get; set; }

        [Column(TypeName = "text")]
        public string TemplateTitle { get; set; }

        [Column(TypeName = "text")]
        public string TemplateDetail { get; set; }

        [StringLength(200)]
        public string ReceiverMobileNumber { get; set; }

        [StringLength(50)]
        public string OfficePhone { get; set; }

        [StringLength(200)]
        public string StreetAddress { get; set; }

        [StringLength(200)]
        public string LocationName { get; set; }

        public int? SmsStatusId { get; set; }
        [ForeignKey("SmsStatusId")]
        public virtual SmsStatus SmsStatus { get; set; }

        public int? FailedCount { get; set; }

        [Column(TypeName = "text")]
        public string ErrorMessage { get; set; }

        #region Base Model, Change Model, Delete Model
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
        #endregion
    }
}