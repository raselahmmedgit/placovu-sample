
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab.SecurityApp.Models
{
    [Table("DocumentInfo", Schema = "App")]
    public class DocumentInfo //: BaseModel
    {
        [Key]
        public int DocumentInfoId { get; set; }

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

        public bool? IsTemporary { get; set; }

        public int DocumentInfoTypeId { get; set; }
        [ForeignKey("DocumentInfoTypeId")]
        public virtual DocumentInfoType DocumentInfoType { get; set; }
    }
}
