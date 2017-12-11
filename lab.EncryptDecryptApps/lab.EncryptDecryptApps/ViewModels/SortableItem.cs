using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.EncryptDecryptApps.ViewModels
{
    public class SortableItem
    {
        public int ItemId { get; set; }
        public int DisplayOrder { get; set; }
        public int UpdatedDisplayOrder { get; set; }
    }
}