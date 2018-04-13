using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.Models
{
    [Table("DocumentInfoType", Schema = "App")]
    public class DocumentInfoType //: BaseNotMapModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int DocumentInfoTypeId { get; set; }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}