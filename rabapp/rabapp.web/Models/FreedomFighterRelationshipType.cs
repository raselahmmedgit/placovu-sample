using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class FreedomFighterRelationshipType
    {
        [Key]
        [Required]
        public int FreedomFighterRelationshipTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Freedom Fighter Relationship")]
        public string FreedomFighterRelationshipTypeName { get; set; }
    }
}