using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeAttendInfo
    {
        [Key]
        [Required]
        public int EmployeeAttendInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Display(Name = "In Time")]
        public TimeSpan? InTime { get; set; }

        [Display(Name = "Out Time")]
        public TimeSpan? OutTime { get; set; }

        [Display(Name = "In Date")]
        public DateTime? InDate { get; set; }

        [Display(Name = "Out Date")]
        public DateTime? OutDate { get; set; }

        [MaxLength(256)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [MaxLength(256)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Attendance Status")]
        public int AttendStatusId { get; set; }

        [ForeignKey("AttendStatusId")]
        public virtual AttendStatus AttendStatus { get; set; }
    }
}