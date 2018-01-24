using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class WeekEndType
    {
        [Key]
        [Required]
        public int WeekEndTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "WeekEnd Type")]
        public string WeekEndTypeName { get; set; }
    }
}