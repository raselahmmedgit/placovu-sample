//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lab.lightbootstrapapps.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProcedureNotificationDetail
    {
        public long NotificationDetailId { get; set; }
        public Nullable<long> PracticeProfileId { get; set; }
        public Nullable<long> NotificationId { get; set; }
        public string NotificationDetailHeader { get; set; }
        public string NotificationDetail { get; set; }
    
        public virtual ProcedureNotification ProcedureNotification { get; set; }
    }
}
