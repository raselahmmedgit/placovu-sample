using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeChildInfo
    {
        [Key]
        [Required]
        public int EmployeeChildInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [MaxLength(120)]
        [Display(Name = "Child Name")]
        public string EmployeeChildName { get; set; }

        [Display(Name = "Age")]
        public int ChildAge { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public int GenderTypeId { get; set; }

        [ForeignKey("GenderTypeId")]
        public virtual GenderType GenderType { get; set; }

    }
}