
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.SecurityApp.Models
{
    [Table("Widget", Schema = "App")]
    public class Widget //: BaseModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int WidgetId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(256)]
        public string Name { get; set; }

        [Display(Name = "Is Admin")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Is Shared")]
        public bool IsShared { get; set; }

        public int WidgetCategoryId { get; set; }
        [ForeignKey("WidgetCategoryId")]
        public virtual WidgetCategory WidgetCategory { get; set; }
    }
}
