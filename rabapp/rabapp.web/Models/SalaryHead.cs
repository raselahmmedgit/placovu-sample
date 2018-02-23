using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class SalaryHead
    {
        [Key]
        [Required]
        public int SalaryHeadId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Salary Head")]
        public string SalaryHeadName { get; set; }

        [Display(Name = "Head Type")]
        public int SalaryHeadTypeId { get; set; }

        [ForeignKey("SalaryHeadTypeId")]
        public virtual SalaryHeadType SalaryHeadType { get; set; }
    }
}