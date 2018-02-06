using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class ShiftDutySchedule
    {
        [Key]
        [Required]
        public int ShiftDutyScheduleId { get; set; }

        [Display(Name = "Shift")]
        public int ShiftId { get; set; }

        [ForeignKey("ShiftId")]
        public virtual Shift Shift { get; set; }

        [Display(Name = "In Time")]
        public TimeSpan InTime { get; set; }

        [Display(Name = "Out Time")]
        public TimeSpan OutTime { get; set; }

        [Display(Name = "Late Time")]
        public TimeSpan LateTime { get; set; }

        [Display(Name = "Early Out Time")]
        public TimeSpan EarlyOutTime { get; set; }
    }
}