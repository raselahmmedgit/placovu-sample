using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace lab.SecurityApp.Models
{
    [Table("ApplicationInfo", Schema = "App")]
    public class ApplicationInfo //: BaseModel
    {
        [Key]
        public int ApplicationInfoId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(128)]
        public string Name { get; set; }

        [Display(Name = "Key")]
        [Required(ErrorMessage = "Key is required")]
        [MaxLength(128)]
        public string Key { get; set; }

        [Display(Name = "Value")]
        [Required(ErrorMessage = "Value is required")]
        [MaxLength(256)]
        public string Value { get; set; }

        [Display(Name = "Description")]
        [MaxLength(400)]
        public string Description { get; set; }
    }
}
