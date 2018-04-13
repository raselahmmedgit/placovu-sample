using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.ComponentModel.DataAnnotations;

namespace lab.SecurityApp.Models
{
    [Table("SMSTemplateCategory", Schema = "App")]
    public class SMSTemplateCategory //: BaseNotMapModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int SMSTemplateCategoryId { get; set; }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
