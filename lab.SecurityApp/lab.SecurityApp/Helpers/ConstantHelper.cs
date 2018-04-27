using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.Helpers
{
    public static class MessageConstantHelper
    {
        public static string DbExceptionError = "Database is currently experiencing problems:";
        public static string UpdateException = "Datebase is currently updating problem.";
        public static string EntityExceptionError = "Entity is problem.";
        public static string NullReferenceExceptionError = "There are one or more required fields that are missing.";
        public static string ApplicationExceptionError = "Exception in application:";
        public static string NullError = "Requested object could not found.";
        public static string CommonError = "Oops! Exception in application.";
    }
}