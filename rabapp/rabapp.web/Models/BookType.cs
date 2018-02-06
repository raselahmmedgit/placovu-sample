using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class BookType
    {
        [Key]
        [Required]
        public int BookTypeId { get; set; }

        [MaxLength(120)]
        [Display(Name = "Book Type")]
        public string BookTypeName { get; set; }
    }
}