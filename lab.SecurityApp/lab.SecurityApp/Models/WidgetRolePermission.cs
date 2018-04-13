
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.SecurityApp.Models
{
    [Table("WidgetRolePermission", Schema = "App")]
    public class WidgetRolePermission //: BaseNotMapModel
    {
        [Key]
        public int WidgetPermissionId { get; set; }

        public int WidgetId { get; set; }
        [ForeignKey("WidgetId")]
        public virtual Widget Widget { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
