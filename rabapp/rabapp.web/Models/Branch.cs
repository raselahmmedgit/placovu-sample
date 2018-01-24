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

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(150)]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(200)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(150)]
        public string MobileNo { get; set; }

        [StringLength(150)]
        public string PhoneNo { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
    }
}