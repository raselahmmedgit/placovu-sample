using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class Shift
    {
        [Key]
        [Required]
        public int ShiftId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Shift Name")]
        public string ShiftName { get; set; }
    }
}