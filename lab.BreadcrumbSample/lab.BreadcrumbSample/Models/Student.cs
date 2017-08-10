using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.BreadcrumbSample.Models
{
    public class Student : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}