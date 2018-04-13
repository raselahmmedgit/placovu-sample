
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.SecurityApp.Models
{
    [Table("MenuRolePermission", Schema = "App")]
    public class MenuRolePermission //: BaseNotMapModel
    {
        [Key]
        public int MenuRolePermissionId { get; set; }

        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
