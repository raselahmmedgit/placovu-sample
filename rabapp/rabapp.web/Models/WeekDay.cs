using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class WeekDay
    {
        [Key]
        [Required]
        public int WeekDayId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Day of Week")]
        public string WeekDayName { get; set; }
    }
}