
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.SecurityApp.Models
{
    [Table("RightRolePermission", Schema = "App")]
    public class RightRolePermission //: BaseNotMapModel
    {
        [Key]
        public int RightRolePermissionId { get; set; }

        public int RightId { get; set; }
        [ForeignKey("RightId")]
        public virtual Right Right { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
