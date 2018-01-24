using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class GenderType
    {
        [Key]
        [Required]
        public int GenderTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Gender Type")]
        public string GenderTypeName { get; set; }
    }
}