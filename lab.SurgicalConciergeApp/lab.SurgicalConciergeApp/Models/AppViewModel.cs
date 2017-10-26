using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SurgicalConciergeApp.Models
{
    public class WorkFlowProcedureViewModel
    {
        public int WorkFlowProcedureId { get; set; }

        public int WorkFlowId { get; set; }

        public string WorkFlowName { get; set; }

        public int ProcedureId { get; set; }

        public string ProcedureName { get; set; }

        public int WorkFlowPatientProfileId { get; set; }

        public int WorkFlowCategoryId { get; set; }

        public string WorkFlowCategoryName { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public bool? HasStart { get; set; }

        public bool? HasEnd { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CurrentDataTime { get; set; }

    }
}