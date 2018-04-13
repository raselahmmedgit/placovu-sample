
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.SecurityApp.Models
{
    [Table("WidgetUserPermission", Schema = "App")]
    public class WidgetUserPermission //: BaseNotMapModel
    {
        [Key]
        public int WidgetPermissionId { get; set; }

        [Display(Name = "Add")]
        public bool IsAdd { get; set; }

        [Display(Name = "Remove")]
        public bool IsRemove { get; set; }

        public int WidgetId { get; set; }
        [ForeignKey("WidgetId")]
        public virtual Widget Widget { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
