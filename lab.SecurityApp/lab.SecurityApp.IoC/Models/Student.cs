using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.IoC.Models
{
    public class Student
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