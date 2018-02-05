using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class ReligionType
    {
        [Key]
        [Required]
        public int ReligionTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Religion Name")]
        public string ReligionTypeName { get; set; }
    }
}