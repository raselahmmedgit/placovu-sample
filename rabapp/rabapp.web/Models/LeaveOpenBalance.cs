using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class LeaveOpenBalance
    {
        [Key]
        [Required]
        public int LeaveOpenBalanceId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Leave Open Balance")]
        public string LeaveOpenBalanceName { get; set; }

        [Display(Name = "Total Leave")]
        public int LeaveTotal { get; set; }

        [Display(Name = "Paid Leave")]
        public int LeavePaid { get; set; }

        [Display(Name = "Balance Leave")]
        public int LeaveBalance { get; set; }

    }
}