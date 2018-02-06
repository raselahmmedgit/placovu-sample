using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class RosterType
    {
        [Key]
        [Required]
        public int RosterTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Roster Name")]
        public string RosterTypeName { get; set; }
    }
}