using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Reflection;

namespace lab.DISample.Helpers
{
    public static class LoggerHelper
    {
        static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void ErrorLog()
        {
            Exception ex = HttpContext.Current.Server.GetLastError();
            ErrorLog(ex);
        }

        public static void ErrorLog(string exception)
        {
            _logger.Error(exception);
        }

        public static void ErrorLog(Exception ex)
        {
            _logger.Error("Error Log: ", ex);
        }

        public static void InfoLog(Exception ex)
        {
            _logger.Info("Info Log: ", ex);
        }

        public static void WarnLog(Exception ex)
        {
            _logger.Warn("Warn Log: ", ex);
        }

        public static string FormatException(Exception ex)
        {
            string exception = "Error Log: ";

            if (ex.InnerException != null)
            {
                exception = "Inner Exception Type: ";
                exception = ex.InnerException.GetType().ToString();
                exception = "Inner Exception: ";
                exception = ex.InnerException.Message;
                exception = "Inner Source: ";
                exception = ex.InnerException.Source;
                if (ex.InnerException.StackTrace != null)
                {
                    exception = "Inner Stack Trace: ";
                    exception = ex.InnerException.StackTrace;
                }
            }

            exception = "Exception Type: ";
            exception = ex.GetType().ToString();
            exception = "Exception: " + ex.Message;
            exception = "Source: " + ex.Source;
            exception = "Stack Trace: ";

            if (ex.StackTrace != null)
            {
                exception = ex.StackTrace;
            }

            return exception;
        }

        public static string Format(object oSource, string nCode, string sMessage, string messageToUser, string systemDefinedMessage, Exception oInnerException)
        {
            StringBuilder sNewMessage = new StringBuilder();
            string sErrorStack = null;
            sErrorStack = BuildErrorStack(oInnerException);
            sNewMessage.Append(Environment.NewLine);
            sNewMessage.Append(DateTime.Now.ToString());
            sNewMessage.Append(Environment.NewLine);
            sNewMessage.Append("Exception Summary :");
            sNewMessage.Append(Environment.NewLine);
            sNewMessage.Append("Error Message :");
            sNewMessage.Append(sMessage);
            sNewMessage.Append(Environment.NewLine);
            sNewMessage.Append("Message To User :");
            sNewMessage.Append(messageToUser);
            sNewMessage.Append(Environment.NewLine);
            sNewMessage.Append("System Defined Message :");
            sNewMessage.Append(systemDefinedMessage);
            sNewMessage.Append(Environment.NewLine);
            sNewMessage.Append("Machine Name :");
            sNewMessage.Append(Environment.MachineName);
            sNewMessage.Append(Environment.NewLine);
            sNewMessage.Append("Domain Name :");
            sNewMessage.Append(System.AppDomain.CurrentDomain.FriendlyName.ToString());
            sNewMessage.Append(Environment.NewLine);
            sNewMessage.Append("Host Name :");
            sNewMessage.Append(System.Net.Dns.GetHostName().ToString());
            sNewMessage.Append(Environment.NewLine);
            sNewMessage.Append("OS Version :");
            sNewMessage.Append(Environment.OSVersion);
            sNewMessage.Append(Environment.NewLine);
            sNewMessage.Append(sErrorStack);
            return sNewMessage.ToString().Trim();
        }

        public static string BuildErrorStack(Exception oChainedException)
        {
            string sErrorStack = null;
            StringBuilder sbErrorStack = new StringBuilder();
            int nErrStackNum = 1;
            System.Exception oInnerException = null;
            if (oChainedException != null)
            {
                sbErrorStack.Append("Error Stack ");
                //.Append("------------------------\n\n");
                oInnerException = oChainedException;
                while (oInnerException != null)
                {
                    sbErrorStack.Append(nErrStackNum)
                    .AppendLine(")\n ");
                    sbErrorStack.Append(oInnerException.Message)
                    .AppendLine("\n");
                    oInnerException =
                    oInnerException.InnerException;
                    nErrStackNum++;
                }
                sbErrorStack.Append("\n");
                sbErrorStack.AppendLine("Call Stack\n");
                sbErrorStack.Append(oChainedException.StackTrace);
                sErrorStack = sbErrorStack.ToString();
            }
            else
            {
                sErrorStack = "exception was not chained";
            }

            return sErrorStack;
        }
    }
}