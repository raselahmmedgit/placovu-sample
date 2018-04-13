using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.ComponentModel.DataAnnotations;

namespace lab.SecurityApp.Models
{
    [Table("Role", Schema = "App")]
    public class Role //: BaseModel
    {
        //[Key]
        //public virtual Guid RoleId { get; set; }
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int RoleId { get; set; }

        [Display(Name = "Role Name")]
        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; }

        //public virtual ICollection<User> Users { get; set; }
    }
}
