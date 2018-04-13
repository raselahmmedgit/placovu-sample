
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.SecurityApp.Models
{
    [Table("SMSTemplate", Schema = "App")]
    public class SMSTemplate //: BaseModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int SMSTemplateId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(256)]
        public string Name { get; set; }

        [Display(Name = "SMS Subject")]
        [StringLength(256)]
        public string SMSSubject { get; set; }

        [Display(Name = "SMS Message")]
        [MaxLength]
        public string SMSMessage { get; set; }

        [Display(Name = "Is Admin")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Is Shared")]
        public bool IsShared { get; set; }

        public int SMSTemplateCategoryId { get; set; }
        [ForeignKey("SMSTemplateCategoryId")]
        public virtual SMSTemplateCategory SMSTemplateCategory { get; set; }
    }
}
