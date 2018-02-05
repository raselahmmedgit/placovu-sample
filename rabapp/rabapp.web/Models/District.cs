using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class District
    {
        [Key]
        [Required]
        public int DistrictId { get; set; }

        [MaxLength(120)]
        [Display(Name = "District Name")]
        public string DistrictName { get; set; }
    }
}