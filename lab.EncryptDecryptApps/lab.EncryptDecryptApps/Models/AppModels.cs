using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab.EncryptDecryptApps.Models
{
    public class BaseModel
    {
        [NotMapped]
        public string SuccessMessage { get; set; }

        [NotMapped]
        public string ErrorMessage { get; set; }

        [NotMapped]
        public bool IsSuccess { get; set; }

        [NotMapped]
        public int Total { get; set; }
    }

    public class User : BaseModel
    {
        public User()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        [Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(64)]
        public byte[] PasswordHash { get; set; }

        [Required]
        [MaxLength(128)]
        public byte[] PasswordSalt { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid email address.")]
        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

        [Display(Name = "Approved?")]
        public bool IsApproved { get; set; }

        [Display(Name = "Create Date")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Last Login Date")]
        public DateTime? DateLastLogin { get; set; }

        [Display(Name = "Last Activity Date")]
        public DateTime? DateLastActivity { get; set; }

        [Display(Name = "Last Password Change Date")]
        public DateTime DateLastPasswordChange { get; set; }

        //public bool IsLoggedIn { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }

    public class Role : BaseModel
    {
        [Key]
        [Display(Name = "Role Name")]
        public virtual string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }


    public class Student : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

    }
}