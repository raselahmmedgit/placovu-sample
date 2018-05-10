using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.Authorized.Net.App.ViewModels
{
    public class ANetApiLineItemType
    {
        public string ItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}