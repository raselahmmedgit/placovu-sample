using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChartDemoApp.Models
{
    public class ChartModel
    {
        public List<string> Labels { get; set; }
        public List<DatasetModel> Series { set; get; }
        public string ChartType { get; set; }
        public string ChartName { set; get; }
    }
}