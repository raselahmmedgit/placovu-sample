using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class JobDuration
    {
        [Key]
        [Required]
        public int JobDurationId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Job Duration Name")]
        public string JobDurationName { get; set; }

        [Display(Name = "Job Duration")]
        public int JobDurationYear { get; set; }
    }
}