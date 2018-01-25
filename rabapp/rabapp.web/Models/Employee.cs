using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int EmployeeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
    }
}