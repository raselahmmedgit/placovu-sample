using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class RosterDutyScheduleDetail
    {
        [Key]
        [Required]
        public int RosterDutyScheduleDetailId { get; set; }

        [Display(Name = "Assign Roster")]
        public int RosterDutyScheduleId { get; set; }

        [ForeignKey("RosterDutyScheduleId")]
        public virtual RosterDutySchedule RosterDutySchedule { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }
    }
}