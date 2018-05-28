using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab.SBThemeApps.ViewModels
{
    public class StudentViewModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        [Required]
        [MaxLength(100)]
        public string StudentName { get; set; }
    }
}