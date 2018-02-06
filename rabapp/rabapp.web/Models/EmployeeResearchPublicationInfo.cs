using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    public class EmployeeResearchPublicationInfo
    {
        [Key]
        [Required]
        public int EmployeeResearchPublicationInfoId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeInfoId { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

        [MaxLength(120)]
        [Display(Name = "Title Article")]
        public string ResearchPublicationTitle { get; set; }

        [MaxLength(120)]
        [Display(Name = "Journal/Book Name")]
        public string BookName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Publish By")]
        public string BookPublishBy { get; set; }

        [Display(Name = "Book Type")]
        public int BookTypeId { get; set; }

        [ForeignKey("BookTypeId")]
        public virtual BookType BookType { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [MaxLength(120)]
        [Display(Name = "ISS Number")]
        public string BookISSNumber { get; set; }

        [Display(Name = "Published Date")]
        public DateTime? BookPublishedDate { get; set; }
    }
}