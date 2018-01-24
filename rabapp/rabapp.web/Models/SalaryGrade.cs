using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class SalaryGrade
    {
        [Key]
        [Required]
        public int SalaryGradeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Salary Grade")]
        public string SalaryGradeName { get; set; }
    }
}