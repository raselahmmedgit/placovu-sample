using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    [Table("Branch", Schema = "dbo")]
    public class Branch
    {
        [Key]
        [Required]
        public int BranchId { get; set; }

        [Display(Name = "Branch Name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(150)]
        public string BranchName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(200)]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [StringLength(250)]
        public string Address { get; set; }

        [Display(Name = "Mobile")]
        [StringLength(150)]
        public string MobileNo { get; set; }

        [Display(Name = "Phone")]
        [StringLength(150)]
        public string PhoneNo { get; set; }

        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
    }
}