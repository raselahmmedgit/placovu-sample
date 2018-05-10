using System;
using System.ComponentModel.DataAnnotations;

namespace lab.SecurityApp.MySql.Models
{
    public class StudentInfo
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int StudentInfoId { get; set; }

        [Display(Name = "Student Name")]
        [Required]
        [MaxLength(100)]
        public string StudentName { get; set; }
    }
}
