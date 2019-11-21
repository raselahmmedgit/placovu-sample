using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChartDemoApp.Models
{
    public class GraphProperty
    {
        public GraphProperty()
        {
            Fill = true;
            PointRadius = 5;
            PointBorderWidth = 5;
            LineTension = 0;
        }
        public string BackgroundColor { get; set; }
        public bool Fill { get; set; }
        public double PointRadius { get; set; }
        public string PointBorderColor { set; get; }
        public string PointBackgroundColor { set; get; }
        public int PointBorderWidth { set; get; }
        public int LineTension { set; get; }
        public string BorderColor { set; get; }
        public void SetFillStatus(string chartType)
        {
            if (chartType.Equals(ChartTypeEnum.bar.ToString()))
            {
                Fill = true;
            }
            else
            {
                Fill = false;
                BackgroundColor = "#fff";
            }
        }
    }
}