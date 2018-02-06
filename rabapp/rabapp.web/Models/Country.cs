using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class Country
    {
        [Key]
        [Required]
        public int CountryId { get; set; }

        [Display(Name = "Country")]
        [StringLength(128)]
        public string CountryName { get; set; }

        [StringLength(128)]
        public string CountryDisplayName { get; set; }

        [Display(Name = "Iso")]
        [StringLength(5)]
        public string CountryIso { get; set; }

        [Display(Name = "Iso 3")]
        [StringLength(5)]
        public string CountryIso3 { get; set; }

        [Display(Name = "Number Code")]
        [StringLength(8)]
        public string NumberCode { get; set; }

        [Display(Name = "Phone Code")]
        [StringLength(8)]
        public string PhoneCode { get; set; }

        public bool IsPublished { get; set; }
    }
}