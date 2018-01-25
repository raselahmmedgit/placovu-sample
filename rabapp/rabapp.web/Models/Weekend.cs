using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class WeekEnd
    {
        [Key]
        [Required]
        public int WeekEndId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Weekend Name")]
        public string WeekEndName { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [Display(Name = "Weekend Type")]
        public int WeekEndTypeId { get; set; }

        [ForeignKey("WeekEndTypeId")]
        public virtual WeekEndType WeekEndType { get; set; }

        [Display(Name = "Weekday")]
        public int WeekDayId { get; set; }

        [ForeignKey("WeekDayId")]
        public virtual WeekDay WeekDay { get; set; }
    }
}