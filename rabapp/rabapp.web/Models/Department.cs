using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int DepartmentId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}