using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class Designation
    {
        [Key]
        [Required]
        public int DesignationId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }
    }
}