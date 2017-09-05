using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab.ElasticSearchApps.Models
{
    [Table("PatientInformation")]
    public partial class PatientInformation
    {
        [Key]
        public int PatientId { get; set; }

        [StringLength(50)]
        public string PatientIdDisplay { get; set; }

        public int? PatientBirthYear { get; set; }

        public int? PatientBirthMonth { get; set; }

        [StringLength(50)]
        public string PatientBirthYearMonth { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}