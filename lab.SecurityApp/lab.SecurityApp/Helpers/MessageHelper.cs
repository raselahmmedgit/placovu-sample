using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.SecurityApp.Helpers
{
    public enum MessageTypeEnum
    {
        None = 1,
        Success = 2,
        Error = 3,
        Information = 4,
        Warning = 5,
        LoginRequired = 6,
    }

    public class Message
    {
        public Message()
        {
            MessageTypeEnum = MessageTypeEnum.None;
        }
        public MessageTypeEnum MessageTypeEnum { get; set; }
        public string CurrentMessage { get; set; }

        public int State { get; set; }

    }

    public static class SetMessage
    {
        public static Message SetSuccessMessage(string currentMessage = "Success !")
        {
            return new Message { MessageTypeEnum = MessageTypeEnum.Success, CurrentMessage = currentMessage, State = 0 };
        }
        public static Message SetErrorMessage(string currentMessage = "Error !")
        {
            return new Message { MessageTypeEnum = MessageTypeEnum.Error, CurrentMessage = currentMessage, State = 0 };
        }
        public static Message SetInformationMessage(string currentMessage = "Information !")
        {
            return new Message { MessageTypeEnum = MessageTypeEnum.Information, CurrentMessage = currentMessage, State = 0 };
        }
        public static Message SetWarningMessage(string currentMessage = "Warning !")
        {
            return new Message { MessageTypeEnum = MessageTypeEnum.Warning, CurrentMessage = currentMessage, State = 0 };
        }
        public static Message SetLoginRequiredMessage(string currentMessage = "Login Required !")
        {
            return new Message { MessageTypeEnum = MessageTypeEnum.LoginRequired, CurrentMessage = currentMessage, State = 0 };
        }
        public static Message SetModelStateErrorMessage(ModelStateDictionary modelStateDictionary)
        {
            var currentMessage = ExceptionHelper.ModelStateErrorFormat(modelStateDictionary);
            return new Message { MessageTypeEnum = MessageTypeEnum.Error, CurrentMessage = currentMessage, State = 0 };
        }
        public static Message SetModelStateFirstOrDefaultErrorMessage(ModelStateDictionary modelStateDictionary)
        {
            var currentMessage = ExceptionHelper.ModelStateFirstOrDefaultErrorFormat(modelStateDictionary);
            return new Message { MessageTypeEnum = MessageTypeEnum.Error, CurrentMessage = currentMessage, State = 0 };
        }
    }
}