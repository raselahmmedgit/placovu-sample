using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.ComponentModel.DataAnnotations;

namespace lab.SecurityApp.Models
{
    [Table("User", Schema = "App")]
    public class User : BaseModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(64)]
        public Byte[] Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

        [Display(Name = "Approved?")]
        public bool IsApproved { get; set; }

        [Display(Name = "Last Login Date")]
        public DateTime? LastLoginDate { get; set; }

        [Display(Name = "Last Activity Date")]
        public DateTime? LastActivityDate { get; set; }

        [Display(Name = "Last Password Change Date")]
        public DateTime LastPasswordChangeDate { get; set; }

        //public bool IsLoggedIn { get; set; }

        //public virtual ICollection<Role> Roles { get; set; }
    }
}
