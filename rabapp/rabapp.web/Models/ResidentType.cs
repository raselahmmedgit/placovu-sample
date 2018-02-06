using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class ResidentType
    {
        [Key]
        [Required]
        public int ResidentTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Resident Type")]
        public string ResidentTypeName { get; set; }
    }
}