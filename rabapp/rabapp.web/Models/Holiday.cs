using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class Holiday
    {
        [Key]
        [Required]
        public int HolidayId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Holiday Name")]
        public string HolidayName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}