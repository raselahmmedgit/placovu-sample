using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class LeaveType
    {
        [Key]
        [Required]
        public int LeaveTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Leave Type")]
        public string LeaveTypeName { get; set; }

        public int LeaveDays { get; set; }

        public int? GenderTypeId { get; set; }

        [ForeignKey("GenderTypeId")]
        public virtual GenderType GenderType { get; set; }

        [Display(Name = "Count Working Day For One Day Leave")]
        public int LeaveCountWorkDayForOneDayLeave { get; set; }
    }
}