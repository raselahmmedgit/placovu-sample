using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class FreedomFighterType
    {
        [Key]
        [Required]
        public int FreedomFighterTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Freedom Fighter")]
        public string FreedomFighterTypeName { get; set; }
    }
}