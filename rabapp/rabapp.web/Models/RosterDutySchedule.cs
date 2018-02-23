using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class RosterDutySchedule
    {
        [Key]
        [Required]
        public int RosterDutyScheduleId { get; set; }

        [Display(Name = "Roster")]
        public int RosterTypeId { get; set; }

        [ForeignKey("RosterTypeId")]
        public virtual RosterType RosterType { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public bool? IsAllEmployee { get; set; }

        [Display(Name = "Shift Schedule")]
        public int ShiftDutyScheduleId { get; set; }

        [ForeignKey("ShiftDutyScheduleId")]
        public virtual ShiftDutySchedule ShiftDutySchedule { get; set; }
    }
}