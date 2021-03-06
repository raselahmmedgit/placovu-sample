﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RnD.AzureLoadBalancer.Models
{
    public class ApplicationSettingViewModel
    {
        [StringLength(50)]
        public string ApplicationId { get; set; }

        [Required]
        [StringLength(50)]
        public string HostAddress { get; set; }

        [StringLength(128)]
        public string DefaultUtcTimeZone { get; set; }

        [StringLength(10)]
        public string DefaultUtcTimeZoneOffset { get; set; }

        public bool? IsMobileDevice { get; set; }

        [StringLength(10)]
        public string MobileNotificationIntervalMinute { get; set; }

        [StringLength(10)]
        public string MobileNotificationElapsedMinute { get; set; }
    }
}