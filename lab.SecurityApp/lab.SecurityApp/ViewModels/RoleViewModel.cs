using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.ViewModels
{
    public class RoleViewModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int RoleId { get; set; }

        [Display(Name = "Role Name")]
        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; }
    }
}