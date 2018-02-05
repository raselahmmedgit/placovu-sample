using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class BloodGroup
    {
        [Key]
        [Required]
        public int BloodGroupId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Blood Group")]
        public string BloodGroupName { get; set; }
    }
}