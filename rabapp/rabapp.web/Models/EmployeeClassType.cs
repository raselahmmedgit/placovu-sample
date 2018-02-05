using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeClassType
    {
        [Key]
        [Required]
        public int EmployeeClassTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Employee Class")]
        public string EmployeeClassTypeName { get; set; }
    }
}