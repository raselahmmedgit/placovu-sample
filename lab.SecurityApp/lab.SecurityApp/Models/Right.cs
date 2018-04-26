using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace lab.SecurityApp.Models
{
    [Table("Right", Schema = "App")]
    public class Right : BaseModel
    {
        [Key]
        public int RightId { get; set; }

        [DisplayName("Name: ")]
        [Required(ErrorMessage = "Right Name is required")]
        [MaxLength(128)]
        public string Name { get; set; }

        [DisplayName("Description: ")]
        [MaxLength(256)]
        public string Description { get; set; }

    }
}
