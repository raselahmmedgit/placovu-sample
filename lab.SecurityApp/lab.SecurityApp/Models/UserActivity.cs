using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.ComponentModel.DataAnnotations;

namespace lab.SecurityApp.Models
{
    [Table("UserActivity", Schema = "App")]
    public class UserActivity //: BaseNotMapModel
    {
        [Key]
        [Required]
        [Display(AutoGenerateField = false)]
        public int UserActivityId { get; set; }
        public DateTime? LogInTimeUtc { get; set; }
        public DateTime? LogOutTimeUtc { get; set; }
        public string BrowserAgent { get; set; }
        public string UserRoleName { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
        public bool? IsMobileDevice { get; set; }
        public string MobileDeviceModel { get; set; }
    }
}
