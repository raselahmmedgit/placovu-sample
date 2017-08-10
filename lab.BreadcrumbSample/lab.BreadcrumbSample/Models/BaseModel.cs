using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab.BreadcrumbSample.Models
{
    public class BaseModel
    {
        [NotMapped]
        public bool IsSuccess { get; set; }

        [NotMapped]
        public string SuccessMessage { get; set; }

        [NotMapped]
        public Boolean IsError { get; set; }

        [NotMapped]
        public string ErrorMessage { get; set; }
    }
}