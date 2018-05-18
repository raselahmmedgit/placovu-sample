using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.DISample.Helpers
{
    public static class ExceptionHelper
    {
        public static string Manage(Exception ex, bool log = false)
        {
            string message = "Error: There was a problem while processing your request: " + ex.Message;

            if (ex.InnerException != null)
            {
                Exception inner = ex.InnerException;
                if (inner is System.Data.Common.DbException)
                    message = MessageConstantHelper.DbExceptionError + inner.Message;
                else if (inner is System.Data.Entity.Core.UpdateException)
                    message = MessageConstantHelper.UpdateExceptionError + inner.Message;
                else if (inner is System.Data.Entity.Core.EntityException)
                    message = MessageConstantHelper.EntityExceptionError + inner.Message;
                else if (inner is NullReferenceException)
                    message = MessageConstantHelper.NullReferenceExceptionError + inner.Message;
                else if (inner is ArgumentException)
                {
                    string paramName = ((ArgumentException)inner).ParamName;
                    message = string.Concat("The ", paramName, " value is illegal.");
                }
                else if (inner is ApplicationException)
                    message = MessageConstantHelper.ApplicationExceptionError + inner.Message;
                else
                    message = inner.Message;

            }

            if (log)
            {
                LoggerHelper.ErrorLog(ex);
            }

            return message;
        }

        public static string ExceptionMessageFormat(Exception ex, bool log = false)
        {
            string message = "Error: There was a problem while processing your request: " + ex.Message;

            if (ex.InnerException != null)
            {
                Exception inner = ex.InnerException;
                if (inner is System.Data.Common.DbException)
                    message = MessageConstantHelper.DbExceptionError + inner.Message;
                else if (inner is System.Data.Entity.Core.UpdateException)
                    message = MessageConstantHelper.UpdateExceptionError + inner.Message;
                else if (inner is System.Data.Entity.Core.EntityException)
                    message = MessageConstantHelper.EntityExceptionError + inner.Message;
                else if (inner is NullReferenceException)
                    message = MessageConstantHelper.NullReferenceExceptionError + inner.Message;
                else if (inner is ArgumentException)
                {
                    string paramName = ((ArgumentException)inner).ParamName;
                    message = string.Concat("The ", paramName, " value is illegal.");
                }
                else if (inner is ApplicationException)
                    message = MessageConstantHelper.ApplicationExceptionError + inner.Message;
                else
                    message = inner.Message;

            }

            if (log)
            {
                LoggerHelper.ErrorLog(message);
            }

            return message;
        }

        public static string ExceptionMessageForNullObject()
        {
            string message = MessageConstantHelper.NullError;

            return message;
        }

        public static string ExceptionErrorMessageFormat(Exception ex)
        {
            string message = "Error: There was a problem while processing your request: " + ex.Message;

            if (ex.InnerException != null)
            {
                Exception inner = ex.InnerException;
                if (inner is System.Data.Common.DbException)
                    message = MessageConstantHelper.DbExceptionError + inner.Message;
                else if (inner is System.Data.Entity.Core.UpdateException)
                    message = MessageConstantHelper.UpdateExceptionError + inner.Message;
                else if (inner is System.Data.Entity.Core.EntityException)
                    message = MessageConstantHelper.EntityExceptionError + inner.Message;
                else if (inner is NullReferenceException)
                    message = MessageConstantHelper.NullReferenceExceptionError + inner.Message;
                else if (inner is ArgumentException)
                {
                    string paramName = ((ArgumentException)inner).ParamName;
                    message = string.Concat("The ", paramName, " value is illegal.");
                }
                else if (inner is ApplicationException)
                    message = MessageConstantHelper.ApplicationExceptionError + inner.Message;
                else
                    message = inner.Message;

            }

            return message;
        }

        public static string ExceptionErrorMessageForNullObject()
        {
            string message = MessageConstantHelper.NullError;

            return message;
        }

        public static string ExceptionErrorMessageForCommon()
        {
            string message = MessageConstantHelper.ErrorCommon;

            return message;
        }

        public static string ModelStateErrorFormat(ModelStateDictionary modelStateDictionary)
        {
            string message = string.Empty;

            foreach (var modelStateValues in modelStateDictionary.Values)
            {
                if (modelStateValues.Errors.Any())
                {
                    foreach (var modelError in modelStateValues.Errors)
                    {
                        message += "<p>";
                        message += modelError.ErrorMessage;
                        message += "</p>";
                    }
                }
            }

            return message;
        }

        public static string ModelStateFirstOrDefaultErrorFormat(ModelStateDictionary modelStateDictionary)
        {
            string message = string.Empty;

            foreach (var modelStateValues in modelStateDictionary.Values)
            {
                if (modelStateValues.Errors.Any())
                {
                    var firstOrDefaultError = modelStateValues.Errors.FirstOrDefault();

                    if (firstOrDefaultError != null)
                    {
                        message = firstOrDefaultError.ErrorMessage;
                    }
                }
            }

            return message;
        }
    }
}