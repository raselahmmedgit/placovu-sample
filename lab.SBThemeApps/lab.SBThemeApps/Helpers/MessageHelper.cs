using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.SBThemeApps.Helpers
{
    public enum AppMessageType
    {
        None = 1,
        Success = 2,
        Error = 3,
        Information = 4,
        Warning = 5,
        LoginRequired = 6
    }

    public class AppMessage
    {
        public AppMessage()
        {
            MessageType = AppMessageType.None;
        }
        public AppMessageType MessageType { get; set; }
        public string CurrentMessage { get; set; }
        public string Message { get; set; }
        public int State { get; set; }

    }

    public static class SetAppMessage
    {
        public static AppMessage SetSuccessMessage(string currentMessage = "Success !", string message = "Success !")
        {
            return new AppMessage { MessageType = AppMessageType.Success, CurrentMessage = currentMessage, Message = message, State = 0 };
        }
        public static AppMessage SetErrorMessage(string currentMessage = "Error !", string message = "Error !")
        {
            return new AppMessage { MessageType = AppMessageType.Error, CurrentMessage = currentMessage, Message = message, State = 0 };
        }
        public static AppMessage SetInformationMessage(string currentMessage = "Information !", string message = "Information !")
        {
            return new AppMessage { MessageType = AppMessageType.Information, CurrentMessage = currentMessage, Message = message, State = 0 };
        }
        public static AppMessage SetWarningMessage(string currentMessage = "Warning !", string message = "Warning !")
        {
            return new AppMessage { MessageType = AppMessageType.Warning, CurrentMessage = currentMessage, Message = message, State = 0 };
        }
        public static AppMessage SetLoginRequiredMessage(string currentMessage = "Login Required !", string message = "Login Required !")
        {
            return new AppMessage { MessageType = AppMessageType.LoginRequired, CurrentMessage = currentMessage, Message = message, State = 0 };
        }
        public static AppMessage SetModelStateErrorMessage(ModelStateDictionary modelStateDictionary)
        {
            var currentMessage = ExceptionHelper.ModelStateErrorFormat(modelStateDictionary);
            return new AppMessage { MessageType = AppMessageType.Error, CurrentMessage = currentMessage, State = 0 };
        }
        public static AppMessage SetModelStateFirstOrDefaultErrorMessage(ModelStateDictionary modelStateDictionary)
        {
            var currentMessage = ExceptionHelper.ModelStateFirstOrDefaultErrorFormat(modelStateDictionary);
            return new AppMessage { MessageType = AppMessageType.Error, CurrentMessage = currentMessage, State = 0 };
        }
    }
}