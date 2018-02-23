using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class GratuityInfo
    {
        [Key]
        [Required]
        public int GratuityInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [Display(Name = "Gratuity")]
        public int GratuityTypeId { get; set; }

        [ForeignKey("GratuityTypeId")]
        public virtual GratuityType GratuityType { get; set; }
    }
}