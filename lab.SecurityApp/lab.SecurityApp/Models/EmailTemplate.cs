
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace lab.SecurityApp.Models
{
    [Table("EmailTemplate", Schema = "App")]
    public class EmailTemplate //: BaseModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int EmailTemplateId { get; set; }
        
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(256)]
        public string Name { get; set; }

        [Display(Name = "Email Subject")]
        [StringLength(256)]
        [AllowHtml]
        public string EmailSubject { get; set; }

        [Display(Name = "Email Message")]
        [MaxLength]
        [DataType(DataType.Html)]
        [AllowHtml]
        public string EmailMessage { get; set; }

        [Display(Name = "Is Admin")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Is Shared")]
        public bool IsShared { get; set; }

        public int EmailTemplateCategoryId { get; set; }
        [ForeignKey("EmailTemplateCategoryId")]
        public virtual EmailTemplateCategory EmailTemplateCategory { get; set; }

    }
}
