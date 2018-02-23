using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class LeaveStatus
    {
        [Key]
        [Required]
        public int LeaveStatusId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Leave Status")]
        public string LeaveStatusName { get; set; }
    }
}