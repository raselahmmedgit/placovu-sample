
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.SecurityApp.Models
{
     [Table("MenuUserPermission", Schema = "App")]
    public class MenuUserPermission //: BaseNotMapModel
    {
        [Key]
        public int MenuUserPermissionId { get; set; }

        [Display(Name = "Add")]
        public bool IsAdd { get; set; }

        [Display(Name = "Remove")]
        public bool IsRemove { get; set; }

        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
