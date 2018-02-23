using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class GratuityType
    {
        [Key]
        [Required]
        public int GratuityTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Gratuity")]
        public string GratuityTypeName { get; set; }

        [Display(Name = "Duration of Gratuity")]
        public int DurationOfYear { get; set; }

        [Display(Name = "Fixed Percent of Gratuity")]
        public double GratuityPercent { get; set; }
    }
}