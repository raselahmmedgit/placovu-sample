using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.ComponentModel.DataAnnotations;

namespace lab.SecurityApp.Models
{
    [Table("EmailTemplateCategory", Schema = "App")]
    public class EmailTemplateCategory //: BaseNotMapModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int EmailTemplateCategoryId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
