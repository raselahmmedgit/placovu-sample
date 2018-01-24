using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class Bank
    {
        [Key]
        [Required]
        public int BankId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [MaxLength(256)]
        [Display(Name = "Bank Address")]
        public string BankAddress { get; set; }

        [MaxLength(120)]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
    }
}