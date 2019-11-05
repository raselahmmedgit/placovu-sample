using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.Blockchain.Models
{
    public class BabyBoomerProfile
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int BabyBoomerProfileId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }

    public class BabyBoomerAttendeeProfileType
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int AttendeeProfileTypeId { get; set; }

        public string Name { get; set; }
    }

    public class BabyBoomerAttendeeProfile
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int AttendeeProfileId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }

    public class BabyBoomerActivityType
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int ActivityTypeId { get; set; }

        public string Name { get; set; }
    }
    public class BabyBoomerActivity
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int ActivityId { get; set; }

        public string Name { get; set; }

        public int ActivityTypeId { get; set; }
        [ForeignKey("ActivityTypeId")]
        public virtual BabyBoomerActivityType BabyBoomerActivityType { get; set; }
    }

    public class BabyBoomerActivityDetail
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int ActivityDetailId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public bool? HasStart { get; set; }

        public bool? HasEnd { get; set; }

        public bool? IsActive { get; set; }

        public int ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public virtual BabyBoomerActivity BabyBoomerActivity { get; set; }

        public int BabyBoomerProfileId { get; set; }
        [ForeignKey("BabyBoomerProfileId")]
        public virtual BabyBoomerProfile BabyBoomerProfile { get; set; }
    }
}
