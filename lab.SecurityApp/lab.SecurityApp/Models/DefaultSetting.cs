using System;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;

namespace lab.SecurityApp.Models
{
    [Table("DefaultSetting", Schema = "App")]
    public class DefaultSetting //: BaseModel
    {
        [Key]
        public int DefaultSettingId { get; set; }

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
