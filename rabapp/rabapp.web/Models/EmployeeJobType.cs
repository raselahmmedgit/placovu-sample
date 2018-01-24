using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeJobType
    {
        [Key]
        [Required]
        public int EmployeeJobTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Employee Job Type")]
        public string EmployeeJobTypeName { get; set; }
    }
}