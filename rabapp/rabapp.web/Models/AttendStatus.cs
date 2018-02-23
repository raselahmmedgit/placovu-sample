using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class AttendStatus
    {
        [Key]
        [Required]
        public int AttendStatusId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Attendance Status")]
        public string AttendStatusName { get; set; }
    }
}