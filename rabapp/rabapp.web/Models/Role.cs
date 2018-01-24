using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rabapp.Models
{
    [Table("Role", Schema = "dbo")]
    public class Role
    {
        //[Key]
        //public virtual Guid RoleId { get; set; }
        [Key]
        [Required]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string RoleName { get; set; }

        //public virtual ICollection<User> Users { get; set; }
    }
}
