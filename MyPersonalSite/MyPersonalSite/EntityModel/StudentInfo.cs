namespace MyPersonalSite.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentInfo")]
    public partial class StudentInfo
    {
        [Key]
        public Guid StudentId { get; set; }

        [StringLength(50)]
        public string StudentName { get; set; }

        [StringLength(50)]
        public string RegNo { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] RowVersion { get; set; }
    }
}
