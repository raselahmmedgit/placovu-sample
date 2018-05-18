using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace lab.DISample.Models
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