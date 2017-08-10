using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.BreadcrumbSample.Models
{
    public static class Constants
    {

        public static List<Student> StudentList = new List<Student>()
        {
            new Student { Id = 1, Name = "SSC Test : Student 001", Email = "mail@gmail.com" },
            new Student { Id = 2, Name = "HSC Test : Student 001", Email = "mail@gmail.com" },
            new Student { Id = 3, Name = "BBA Test : Student 001", Email = "mail@gmail.com" },
            new Student { Id = 4, Name = "MBA Test : Student 001", Email = "mail@gmail.com" },
            new Student { Id = 5, Name = "PHD Test : Student 001", Email = "mail@gmail.com" },
            new Student { Id = 6, Name = "RASEL Test : Student 001", Email = "mail@gmail.com" },
            new Student { Id = 7, Name = "AHMMED Test : Student 001", Email = "mail@gmail.com" }
        };

        public static class Messages
        {
            public const string UnhandelledError = "We are facing some problem while processing the current request. Please try again later.";
            public const string NotFound = "Requested object not found.";
            public const string SaveSuccess = "Save successfully.";
            public const string UpdateSuccess = "Update successfully.";
            public const string DeleteSuccess = "Delete successfully.";

            public static string ExceptionError(Exception exception)
            {
                return "We are facing some problem while processing the current request. Please try again later. " + exception.Message;
            }
        }
    }
}