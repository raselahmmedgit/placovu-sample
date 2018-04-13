using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.ComponentModel.DataAnnotations;

namespace lab.SecurityApp.Models
{
    [Table("WidgetCategory", Schema = "App")]
    public class WidgetCategory //: BaseNotMapModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int WidgetCategoryId { get; set; }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
