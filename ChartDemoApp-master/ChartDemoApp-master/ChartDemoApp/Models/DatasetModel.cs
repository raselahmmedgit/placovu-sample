using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChartDemoApp.Models
{
    public class DatasetModel
    {
        public DatasetModel()
        {
            GraphProperty = new GraphProperty();
        }
        public string LabelName { get; set; }
        public List<decimal> DataList { get; set; }
        public GraphProperty GraphProperty { set; get; }
        
    }

    
}