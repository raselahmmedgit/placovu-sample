
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.SecurityApp.Models
{
    [Table("RightUserPermission", Schema = "App")]
    public class RightUserPermission //: BaseNotMapModel
    {
        [Key]
        public int RightUserPermissionId { get; set; }

        [Display(Name = "Add")]
        public bool IsAdd { get; set; }

        [Display(Name = "Remove")]
        public bool IsRemove { get; set; }

        public int RightId { get; set; }
        [ForeignKey("RightId")]
        public virtual Right Right { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
