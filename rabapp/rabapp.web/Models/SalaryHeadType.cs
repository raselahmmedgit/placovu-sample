using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class SalaryHeadType
    {
        [Key]
        [Required]
        public int SalaryHeadTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Head Type")]
        public string SalaryHeadTypeName { get; set; }
    }
}