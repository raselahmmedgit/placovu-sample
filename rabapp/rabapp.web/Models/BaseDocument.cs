using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rabapp.web.Models
{
    [Table("BaseDocument")]
    public class BaseDocument
    {
        [Key]
        [Required]
        public int DocumentId { get; set; }

        [StringLength(50)]
        public string DocumentType { get; set; }

        [StringLength(250)]
        public string DocumentName { get; set; }

        [StringLength(250)]
        public string DocumentPath { get; set; }

        [StringLength(50)]
        public string DocumentContentType { get; set; }

        public int? DocumentLength { get; set; }

        public byte[] DocumentContent { get; set; }

        public DateTime? DocumentUploadDate { get; set; }

        public bool? IsTemporaryDocument { get; set; }

    }
}