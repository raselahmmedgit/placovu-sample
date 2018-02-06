using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeCurriculamActivitieInfo
    {
        [Key]
        [Required]
        public int EmployeeCurriculamActivitieInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}