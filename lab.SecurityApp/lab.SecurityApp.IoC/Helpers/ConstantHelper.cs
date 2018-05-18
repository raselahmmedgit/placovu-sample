using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.IoC.Helpers
{
    public static class MessageConstantHelper
    {
        public static string DbExceptionError = "Database is currently experiencing problems:";
        public static string UpdateExceptionError = "Datebase is currently updating problem.";
        public static string EntityExceptionError = "Entity is problem.";
        public static string NullReferenceExceptionError = "There are one or more required fields that are missing.";
        public static string ApplicationExceptionError = "Exception in application:";

        public static string NullError = "Requested object could not found.";
        public static string ErrorCommon = "Oops! Exception in application.";
        public static string ModelValidError = "Form is not valid.";

        public static string Error401 = "Oops! Exception in application.";
        public static string Error403 = "Oops! Exception in application.";
        public static string Error404 = "Oops! Exception in application.";
        public static string Error405 = "Oops! Exception in application.";
        public static string Error406 = "Oops! Exception in application.";
        public static string Error408 = "Oops! Exception in application.";
        public static string Error412 = "Oops! Exception in application.";
        public static string Error500 = "Oops! Exception in application.";
        public static string Error501 = "Oops! Exception in application.";
        public static string Error502 = "Oops! Exception in application.";

        public static string SaveSuccessMessage = "Data has been saved successfully.";
        public static string SaveInformationMessage = "Data has not been saved.";
        public static string UpdateSuccessMessage = "Data has been updated successfully.";
        public static string UpdateInformationMessage = "Data has not been updated.";
        public static string DeleteSuccessMessage = "Data has been deleted successfully.";
        public static string DeleteInformationMessage = "Data has not been deleted.";

    }
}