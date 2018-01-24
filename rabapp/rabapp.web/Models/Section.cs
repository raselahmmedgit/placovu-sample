using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class Section
    {
        [Key]
        [Required]
        public int SectionId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }
    }
}