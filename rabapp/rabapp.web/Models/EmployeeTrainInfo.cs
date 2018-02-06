using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeTrainInfo
    {
        [Key]
        [Required]
        public int EmployeeTrainInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [MaxLength(120)]
        [Display(Name = "Training Title")]
        public string TrainingTitle { get; set; }

        [MaxLength(120)]
        [Display(Name = "Topics Covered")]
        public string TopicsCovered  { get; set; }

        [MaxLength(120)]
        [Display(Name = "Institute")]
        public string InstituteName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Location")]
        public string TrainingLocation { get; set; }

        [MaxLength(120)]
        [Display(Name = "Duration")]
        public string TrainingDuration { get; set; }

    }
}