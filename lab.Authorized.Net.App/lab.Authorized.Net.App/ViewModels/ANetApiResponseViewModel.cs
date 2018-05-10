using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.Authorized.Net.App.ViewModels
{
    public class ANetApiResponseViewModel
    {
        public string TransactionID { get; set; }
        public string ResponseCode { get; set; }
        public string MessageCode { get; set; }
        public string MessageDescription { get; set; }
        public string AuthCode { get; set; }

        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
}