using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class LoanType
    {
        [Key]
        [Required]
        public int LoanTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Loan Type")]
        public string LoanTypeName { get; set; }
    }
}