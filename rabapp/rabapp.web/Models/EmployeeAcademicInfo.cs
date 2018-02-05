using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeAcademicInfo
    {
        [Key]
        [Required]
        public int EmployeeAcademicInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [MaxLength(120)]
        [Display(Name = "Exam Degree")]
        public string DegreeName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Concentration")]
        public string ConcentrationName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Institute")]
        public string InstituteName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Board/University")]
        public string BoardUniversityName { get; set; }

        [Display(Name = "Grade Marks")]
        public int GradeMarks { get; set; }

        [Display(Name = "Out Of")]
        public int GradeMarksOutOf { get; set; }

        [Display(Name = "Percentage")]
        public int GradeMarksPercentage { get; set; }

        [Display(Name = "Year Of Passing")]
        public int PassingYear { get; set; }

    }
}