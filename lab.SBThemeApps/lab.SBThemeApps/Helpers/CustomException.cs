using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Text;
using System.Xml;

namespace lab.SBThemeApps.Helpers
{
    [Serializable()]
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class CustomExceptionDescription : Attribute
    {
        private readonly CustomExceptionPriority _priority;
        public CustomExceptionPriority Priority
        {
            get
            {
                return this._priority;
            }
        }

        private readonly string _defaultErrorMessage;
        public string DefaultErrorMessage
        {
            get
            {
                return this._defaultErrorMessage;
            }
        }

        public CustomExceptionDescription(string defaultErrorMessage, CustomExceptionPriority priority)
            : base()
        {
            this._priority = priority;
            this._defaultErrorMessage = defaultErrorMessage;
        }
    }

    #region Exception Priority
    /// <summary>
    /// <para>Low-Exception is logged only</para>
    /// <para>AboveLow-User is redirected to error page and Message is displayed to the user</para>
    /// <para>Normal-Message is displayed to the user</para>
    /// <para>AboveNormal-Exception is logged and message is displayed</para>
    /// <para>High-Exception is logged, administrator is alerted and message is displayed</para>
    /// <para>VeryHigh-Exception is logged, administrator is alerted and user is redirected to error page</para>
    /// </summary>
    [Serializable()]
    public enum CustomExceptionPriority : int
    {
        /// <summary>
        /// Exception is logged only
        /// </summary>
        Low = 1,
        /// <summary>
        /// User is redirected to error page and Message is displayed to the user
        /// </summary>
        AboveLow = 2,
        /// <summary>
        /// Message is displayed to the user
        /// </summary>
        Normal = 3,
        /// <summary>
        /// Exception is logged and message is displayed
        /// </summary>
        AboveNormal = 4,
        /// <summary>
        /// Exception is logged, administrator is alerted and message is displayed
        /// </summary>
        High = 5,
        /// <summary>
        /// Exception is logged, administrator is alerted and user is redirected to error page
        /// </summary>
        VeryHigh = 6,
        /// <summary>
        /// Administrator is alerted by notification
        /// </summary>
        Critical = 7
    }

    #endregion

    #region Exception Types
    /// <summary>
    /// All Custom Exceptions Types
    /// EnumDescription represents the default error message of the respective exception
    /// EnumName represents the exception type
    /// EnumValue represents the exception code. Its a 6 digits code. First 3 digits represents the module no and last 3 digits represents exception code.
    /// </summary>
    [Serializable()]
    public enum CustomExceptionType : int
    {
        //User Registration & Login Exceptions Code 001
        [CustomExceptionDescription("Invalid User Name", CustomExceptionPriority.Normal)]
        URInvalidUserName = 001001,
        [CustomExceptionDescription("Invalid Password", CustomExceptionPriority.Normal)]
        URInvalidPassword = 001002,
        [CustomExceptionDescription("Duplicate User Name", CustomExceptionPriority.Normal)]
        URDuplicateUser = 001003,
        [CustomExceptionDescription("Captcha Security Violated", CustomExceptionPriority.Normal)]
        URCaptchaSecurity = 001004,
        [CustomExceptionDescription("User is blocked", CustomExceptionPriority.Normal)]
        URUserBlocked = 001005,
        [CustomExceptionDescription("Unknown error occured while user login", CustomExceptionPriority.High)]
        UserLoginUnknownError = 001006,

        //All Common Exceptions. Code 002
        [CustomExceptionDescription("Not have permission to access this page", CustomExceptionPriority.AboveLow)]
        CommonPageAccessDenied = 002001,
        [CustomExceptionDescription("Server Error", CustomExceptionPriority.AboveNormal)]
        CommonServerError = 002002,
        [CustomExceptionDescription("Unhandeled exception found", CustomExceptionPriority.VeryHigh)]
        CommonUnhandled = 002003,
        [CustomExceptionDescription("Argument Null Exception", CustomExceptionPriority.Normal)]
        CommonArgumentNullException = 002004,
        [CustomExceptionDescription("Invalid Argument", CustomExceptionPriority.Normal)]
        CommonInvalidArgument = 002005,
        [CustomExceptionDescription("Invalid Operation", CustomExceptionPriority.Normal)]
        CommonInvalidOperation = 002006,
        [CustomExceptionDescription("Data Dependency Violation", CustomExceptionPriority.Normal)]
        CommonDependencyViolation = 002007,
        [CustomExceptionDescription("Duplicate Data Operation", CustomExceptionPriority.Normal)]
        CommonDuplicacy = 002008,
        [CustomExceptionDescription("Transaction time out", CustomExceptionPriority.High)]
        CommonTransaction = 002009,
        [CustomExceptionDescription("Error While Serialization Process", CustomExceptionPriority.Low)]
        CommonSerialization = 002010,
        [CustomExceptionDescription("Critical Data Not Found", CustomExceptionPriority.AboveNormal)]
        CommonCriticalDataNotFound = 002011,
        [CustomExceptionDescription("Invalid Data", CustomExceptionPriority.Normal)]
        CommonInvalidData = 002012,
        [CustomExceptionDescription("Successfull Operation", CustomExceptionPriority.Normal)]
        CommonSuccess = 002013,
        [CustomExceptionDescription("Not Allowed", CustomExceptionPriority.Normal)]
        CommonNotAllowed = 002014,
        [CustomExceptionDescription("Validation Message", CustomExceptionPriority.Normal)]
        CommonValidation = 002015,

        //File Upload Exceptions. Code 3
        [CustomExceptionDescription("Error while uploading the file to local server", CustomExceptionPriority.High)]
        FileUploadErrorInServer = 003001,
        [CustomExceptionDescription("Error while uploading/updating/deleting a file to/from youtube", CustomExceptionPriority.High)]
        FileUploadErrorInYoutube = 003002,
        [CustomExceptionDescription("Error while saving/deleting the file to/from database", CustomExceptionPriority.High)]
        FileUploadErrorInDatabase = 003003,
        [CustomExceptionDescription("Error while deleting the file from local server", CustomExceptionPriority.Low)]
        FileUploadErrorInDeletingFile = 003004,
        [CustomExceptionDescription("Video not found in youtube", CustomExceptionPriority.High)]
        FileUploadFileNotFoundInYoutube = 003005,

        //Data Access Layer Based Exceptions. Code 4
        [CustomExceptionDescription("Insert data operation failed.", CustomExceptionPriority.High)]
        DataInsertOperation = 004001,
        [CustomExceptionDescription("Update data operation failed.", CustomExceptionPriority.High)]
        DataUpdateOperation = 004002,
        [CustomExceptionDescription("Delete data operation failed.", CustomExceptionPriority.High)]
        DataDeleteOperation = 004003,
        [CustomExceptionDescription("Error while fetching data from database.", CustomExceptionPriority.High)]
        DataFetchOperation = 004004,

        //Cache Based Exceptions. Code 5
        [CustomExceptionDescription("Error while adding cache entry", CustomExceptionPriority.Low)]
        CacheAdd = 005001,
        [CustomExceptionDescription("Error while removing cache entry.", CustomExceptionPriority.Low)]
        CacheRemove = 005002,
        [CustomExceptionDescription("Error while initializing cache", CustomExceptionPriority.Low)]
        CacheInvalid = 005003,
        [CustomExceptionDescription("Error while reading cache configuration", CustomExceptionPriority.Low)]
        CacheConfig = 005004,

        //Exception Framwork Exceptions. Code 6
        [CustomExceptionDescription("Error while logging an exception", CustomExceptionPriority.Critical)]
        ExceptionLogInsert = 006001,
        [CustomExceptionDescription("Error while viewing the log", CustomExceptionPriority.Normal)]
        ExceptionLogDisplay = 006002,
        [CustomExceptionDescription("Error while sending alert to administrator.", CustomExceptionPriority.Low)]
        ExceptionAlert = 006003,
        [CustomExceptionDescription("Error while displaying exception message to user", CustomExceptionPriority.Low)]
        ExceptionDisplayMessage = 006004,

        //Open Inviter Exceptions. Code 7
        [CustomExceptionDescription("Error while connecting to server", CustomExceptionPriority.Normal)]
        OIServerNotAvailable = 007001,
        [CustomExceptionDescription("Error while authenticating user", CustomExceptionPriority.Normal)]
        OIInvalidAuthentication = 007002,
        [CustomExceptionDescription("Open Inviter is not configured properly.", CustomExceptionPriority.AboveNormal)]
        OINotConfigured = 007003,
        [CustomExceptionDescription("Error while importing contacts.", CustomExceptionPriority.Normal)]
        OIUnableToImportContact = 007004,
        [CustomExceptionDescription("Error while importing providers.", CustomExceptionPriority.Normal)]
        OIUnableToImportProvider = 007005,

        //Login Process Failed
        [CustomExceptionDescription("User not found", CustomExceptionPriority.Normal)]
        LPUserNotFound = 008001,
        [CustomExceptionDescription("User has no role assigned", CustomExceptionPriority.Normal)]
        LPUserNotAssignedToRole = 008002,
        [CustomExceptionDescription("User role is not defined", CustomExceptionPriority.Normal)]
        LPUndefinedUserRole = 008003,
        [CustomExceptionDescription("Dependent data not found", CustomExceptionPriority.AboveNormal)]
        LPUserNotAssignedToMember = 008004,
        [CustomExceptionDescription("Error while authenticating user", CustomExceptionPriority.Normal)]
        LPInvalidAuthentication = 008005,

        //Email
        [CustomExceptionDescription("Error while sending email : Smtp not configured", CustomExceptionPriority.High)]
        EmailSMTPNotConfigured = 009001,
        [CustomExceptionDescription("Error while sending email : Smtp server is not responding", CustomExceptionPriority.High)]
        EmailSMTPNotResponding = 009002,
        [CustomExceptionDescription("Error while sending email : Email body is not found", CustomExceptionPriority.Normal)]
        EmailBodyNotFound = 009003,
        [CustomExceptionDescription("Error while sending email : Email subject not found", CustomExceptionPriority.Normal)]
        EmailSubjectNotFound = 009004,
        [CustomExceptionDescription("Error while sending email : recipient is not available", CustomExceptionPriority.Normal)]
        EmailRecipientNotFound = 009005,
        [CustomExceptionDescription("Error while sending email : Sender not found", CustomExceptionPriority.Normal)]
        EmailSenderNotFound = 009006,
        [CustomExceptionDescription("Error while sending email : Invalid recipient email address found", CustomExceptionPriority.AboveNormal)]
        EmailInvalidRecipient = 009007,
        [CustomExceptionDescription("Error while sending the email : attachment size is exceeded the limit", CustomExceptionPriority.Normal)]
        EmailInvalidAttachment = 009008,
        [CustomExceptionDescription("Error while sending email : Invalid email address", CustomExceptionPriority.AboveNormal)]
        EmailInvalidAddress = 009009,
        [CustomExceptionDescription("Email delivery failed", CustomExceptionPriority.AboveNormal)]
        EmailDeliveryFailed = 009010,
        [CustomExceptionDescription("Error while generating email body", CustomExceptionPriority.Normal)]
        EmailMessageBuilderError = 009011,
        [CustomExceptionDescription("Error while generating email body : Template not found", CustomExceptionPriority.Normal)]
        EmailTemplateNotFound = 009012,
        [CustomExceptionDescription("Error while sending email : Email system disabled", CustomExceptionPriority.Low)]
        EmailSystemDisabled = 009013,

        //CMS. Code 010
        [CustomExceptionDescription("Content not found.", CustomExceptionPriority.Normal)]
        CMSContentNotFound = 010001,

        //Batch Processor. Code 011
        [CustomExceptionDescription("Batch processor service aborted unexpectedly.", CustomExceptionPriority.Low)]
        BPAborted = 011001,
        [CustomExceptionDescription("Batch processor service executed successfully.", CustomExceptionPriority.Low)]
        BPSuccess = 011002,
        [CustomExceptionDescription("Batch processor web service is not reachable.", CustomExceptionPriority.Low)]
        BPWebServiceNotFound = 011003,
        [CustomExceptionDescription("Batch processor web service access denied.", CustomExceptionPriority.Low)]
        BPWebServiceAccessDenied = 011004,
        [CustomExceptionDescription("Job distribution failed due to unknown error", CustomExceptionPriority.Low)]
        BPJobDistributionFailed = 011005,

        //Batch Processor. Code 012
        [CustomExceptionDescription("No xml schema found for the provided site.", CustomExceptionPriority.AboveNormal)]
        XMLFeedSchemaNotFound = 012001,
        [CustomExceptionDescription("Error while xml serialization of objects.", CustomExceptionPriority.AboveNormal)]
        XMLFeedSerializationError = 012002,
        [CustomExceptionDescription("Undefined error occured while generating xml feed.", CustomExceptionPriority.AboveNormal)]
        XMLFeedUnhandled = 012003,
        [CustomExceptionDescription("Data not found while generating xml feed.", CustomExceptionPriority.AboveNormal)]
        XMLFeedDataNotFound = 012004,

        //SMS
        [CustomExceptionDescription("Error while sending SMS : SMS Server not configured", CustomExceptionPriority.High)]
        SMSServerNotConfigured = 013001,
        [CustomExceptionDescription("Error while sending SMS : SMS Server is not responding", CustomExceptionPriority.High)]
        SMSServerNotResponding = 013002,
        [CustomExceptionDescription("Error while sending SMS : SMS body is not provided", CustomExceptionPriority.Normal)]
        SMSBodyNotFound = 013003,
        [CustomExceptionDescription("Error while sending SMS : Recipient number is not provided", CustomExceptionPriority.Normal)]
        SMSRecipientNotFound = 013004,
        [CustomExceptionDescription("Error while sending SMS : Sender information is not provided", CustomExceptionPriority.Normal)]
        SMSSenderNotFound = 013005,
        [CustomExceptionDescription("Error while sending SMS : Invalid recipient phone number found", CustomExceptionPriority.Normal)]
        SMSInvalidRecipient = 013006,
        [CustomExceptionDescription("SMS delivery failed", CustomExceptionPriority.Normal)]
        SMSDeliveryFailed = 013007,

        //LinkedIn API Exceptions. Code 014
        [CustomExceptionDescription("LinkedIn is not configured properly.", CustomExceptionPriority.AboveNormal)]
        LinkedInAPINotConfigured = 014001,
        [CustomExceptionDescription("Error while importing LinkedIn profile.", CustomExceptionPriority.Normal)]
        LinkedInAPIUnableToImportProfile = 014002,

        //Facebook API Exceptions. Code 015
        [CustomExceptionDescription("Facebook API is not configured properly.", CustomExceptionPriority.Low)]
        FacebookAPINotConfigured = 015001,
        [CustomExceptionDescription("The Facebook User trying to access the API is not loggedin.", CustomExceptionPriority.Low)]
        FacebookAPIUserNotLoggedIn = 015002,
        [CustomExceptionDescription("The Facebook API is disabled from the config file", CustomExceptionPriority.Low)]
        FacebookAPIDisabled = 015003,
        [CustomExceptionDescription("Unable to post", CustomExceptionPriority.Low)]
        FacebookAPIFailed = 015004,

        //Subscription Manager Exceptions. Code 016
        [CustomExceptionDescription("Problem while intialiazing subscription manager.", CustomExceptionPriority.Normal)]
        SubscriptionManagerInitializationError = 016001,
        [CustomExceptionDescription("Subscription data not found for the logged in user", CustomExceptionPriority.Normal)]
        SubscriptionManagerDataNotFound = 016002,
        [CustomExceptionDescription("The operation is not allowed for the logged in user", CustomExceptionPriority.Normal)]
        SubscriptionManagerActionNotAllowed = 016003,

        //Twitter API Exceptions. Code 017
        [CustomExceptionDescription("Twitter API is not configured properly.", CustomExceptionPriority.Low)]
        TwitterAPINotConfigured = 017001,
        [CustomExceptionDescription("The Twitter User trying to access the API is not loggedin.", CustomExceptionPriority.Low)]
        TwitterAPIUserNotLoggedIn = 017002,
        [CustomExceptionDescription("The Twitter API is disabled from the config file", CustomExceptionPriority.Low)]
        TwitterAPIDisabled = 017003,
        [CustomExceptionDescription("Unable to post", CustomExceptionPriority.Low)]
        TwitterAPIFailed = 017004,

        //HelloTxt API Exceptions. Code 018
        [CustomExceptionDescription("HelloTxt API is not configured properly.", CustomExceptionPriority.Low)]
        HelloTxtAPINotConfigured = 018001,
        [CustomExceptionDescription("The HelloTxt API is disabled from the config file", CustomExceptionPriority.Low)]
        HelloTxtAPIDisabled = 018002,
        [CustomExceptionDescription("Unable to post", CustomExceptionPriority.Low)]
        HelloTxtAPIFailed = 018003,
    }

    #endregion

    [Serializable]
    public class CustomException : ApplicationException
    {
        #region Member Variables

        readonly string _customExceptionUserDefinedMessage = string.Empty;
        readonly string _customExceptionSystemMessage = string.Empty;

        #endregion

        #region Properties

        public CustomExceptionType ExceptionType
        {
            get;
            set;
        }

        public CustomExceptionPriority ExceptionPriority
        {
            get;
            set;
        }

        public string SystemDefinedMessage
        {
            get { return _customExceptionSystemMessage; }
        }

        public string UserDefinedMessage
        {
            get { return _customExceptionUserDefinedMessage; }
        }

        public override string Message
        {
            get
            {
                if (!String.IsNullOrEmpty(base.Message) && base.Message.Trim() != "Error in the application.")
                {
                    return base.Message;
                }
                else
                {
                    return _customExceptionUserDefinedMessage;
                }
            }
        }

        public override string ToString()
        {
            return "Custom Exception: " + base.Message + "\n" + base.StackTrace;
        }

        #endregion

        #region Methods

        public string GetDefaultMessage(Enum value)
        {
            Type type = value.GetType();
            MemberInfo[] memInfo = type.GetMember(value.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(
                typeof(CustomExceptionDescription),
                false);
                if (attrs != null && attrs.Length > 0)

                    return ((CustomExceptionDescription)attrs[0]).DefaultErrorMessage;
            }
            return value.ToString();
        }

        public CustomExceptionDescription GetExceptionDetail(Enum value)
        {
            Type type = value.GetType();
            MemberInfo[] memInfo = type.GetMember(value.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(
                typeof(CustomExceptionDescription),
                false);
                if (attrs != null && attrs.Length > 0)

                    return ((CustomExceptionDescription)attrs[0]);
            }
            return null;
        }

        public byte[] GetSerializedContent()
        {
            try
            {
                StringBuilder xmlContent = new StringBuilder();
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Encoding = Encoding.UTF8;
                xmlWriterSettings.CloseOutput = true;
                xmlWriterSettings.OmitXmlDeclaration = true;
                XmlWriter xmlWriter = XmlWriter.Create(xmlContent, xmlWriterSettings);
                xmlWriter.WriteStartElement("CustomException");
                xmlWriter.WriteElementString("ExceptionType", this.ExceptionType.ToString());
                xmlWriter.WriteElementString("ExceptionPriority", this.ExceptionPriority.ToString());
                xmlWriter.WriteStartElement("UserMessage");
                xmlWriter.WriteCData(this.Message);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("SystemMessage");
                xmlWriter.WriteCData(this.SystemDefinedMessage);
                xmlWriter.WriteEndElement();
                Exception innerException = this.InnerException;
                int innerExceptionCount = 0;

                while (innerException != null)
                {
                    innerExceptionCount++;
                    xmlWriter.WriteStartElement("InnerException");
                    xmlWriter.WriteElementString("Message", innerException.Message);
                    xmlWriter.WriteElementString("Source", innerException.Source);
                    xmlWriter.WriteElementString("StackTrace", innerException.StackTrace);
                    innerException = innerException.InnerException;
                }
                for (int i = 0; i < innerExceptionCount; i++)
                {
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                xmlWriter.Flush();
                xmlWriter.Close();
                return Encoding.UTF8.GetBytes(xmlContent.ToString());
            }
            catch (Exception ex)
            {
                CustomException newException = new CustomException(CustomExceptionType.CommonSerialization, "Error While Serialization Of Exception", ex);
                ExceptionHelper.Manage(newException);
            }
            return default(byte[]);
        }

        #endregion

        #region Constructors

        public CustomException()
            : base()
        {
            ExceptionType = CustomExceptionType.CommonUnhandled;
            CustomExceptionDescription exceptionDetail = GetExceptionDetail(ExceptionType);
            if (exceptionDetail != null)
            {
                ExceptionPriority = exceptionDetail.Priority;
                _customExceptionUserDefinedMessage = exceptionDetail.DefaultErrorMessage;
                _customExceptionSystemMessage = _customExceptionUserDefinedMessage;
            }
        }

        public CustomException(CustomExceptionType exceptionType)
            : base()
        {
            ExceptionType = exceptionType;
            CustomExceptionDescription exceptionDetail = GetExceptionDetail(exceptionType);
            if (exceptionDetail != null)
            {
                ExceptionPriority = exceptionDetail.Priority;
                _customExceptionUserDefinedMessage = exceptionDetail.DefaultErrorMessage;
                _customExceptionSystemMessage = _customExceptionUserDefinedMessage;
            }
        }

        public CustomException(CustomExceptionType exceptionType, string userAlertMessage)
            : base(userAlertMessage)
        {
            ExceptionType = exceptionType;
            CustomExceptionDescription exceptionDetail = GetExceptionDetail(exceptionType);
            ExceptionPriority = exceptionDetail.Priority;
            if (String.IsNullOrEmpty(userAlertMessage))
            {
                _customExceptionUserDefinedMessage = exceptionDetail.DefaultErrorMessage;
            }
            else
            {
                _customExceptionUserDefinedMessage = userAlertMessage;
            }
            _customExceptionSystemMessage = _customExceptionUserDefinedMessage;
        }

        /// <summary>
        /// This overload should be used for successfull operation
        /// </summary>
        /// <param name="userAlertSuccessMessage">message to display to the user</param>
        public CustomException(string userAlertSuccessMessage)
            : base(userAlertSuccessMessage)
        {
            ExceptionType = CustomExceptionType.CommonSuccess;
            CustomExceptionDescription exceptionDetail = GetExceptionDetail(ExceptionType);
            ExceptionPriority = exceptionDetail.Priority;
            if (String.IsNullOrEmpty(userAlertSuccessMessage))
            {
                _customExceptionUserDefinedMessage = exceptionDetail.DefaultErrorMessage;
            }
            else
            {
                _customExceptionUserDefinedMessage = userAlertSuccessMessage;
            }
            _customExceptionSystemMessage = _customExceptionUserDefinedMessage;
        }

        public CustomException(CustomExceptionType exceptionType, string userAlertMessage, string systemMessage, Exception ex)
            : base(userAlertMessage, ex)
        {
            ExceptionType = exceptionType;
            CustomExceptionDescription exceptionDetail = GetExceptionDetail(exceptionType);
            ExceptionPriority = exceptionDetail.Priority;
            if (String.IsNullOrEmpty(userAlertMessage))
            {
                _customExceptionUserDefinedMessage = exceptionDetail.DefaultErrorMessage;
            }
            else
            {
                _customExceptionUserDefinedMessage = userAlertMessage;
            }
            if (!String.IsNullOrEmpty(systemMessage))
            {
                _customExceptionSystemMessage = systemMessage;
            }
            else if (ex != null)
            {
                _customExceptionSystemMessage = ex.Message;
            }
            else
            {
                _customExceptionSystemMessage = _customExceptionUserDefinedMessage;
            }
        }

        public CustomException(CustomExceptionType exceptionType, string userAlertMessage, Exception ex)
            : base(userAlertMessage, ex)
        {
            ExceptionType = exceptionType;
            CustomExceptionDescription exceptionDetail = GetExceptionDetail(exceptionType);
            ExceptionPriority = exceptionDetail.Priority;
            if (String.IsNullOrEmpty(userAlertMessage))
            {
                _customExceptionUserDefinedMessage = exceptionDetail.DefaultErrorMessage;
            }
            else
            {
                _customExceptionUserDefinedMessage = userAlertMessage;
            }
            if (ex != null)
            {
                _customExceptionSystemMessage = ex.Message;
            }
            else
            {
                _customExceptionSystemMessage = _customExceptionUserDefinedMessage;
            }
        }

        public CustomException(CustomExceptionType exceptionType, string userAlertMessage, Exception ex, Object source)
            : base(userAlertMessage, ex)
        {
            ExceptionType = exceptionType;
            CustomExceptionDescription exceptionDetail = GetExceptionDetail(exceptionType);
            ExceptionPriority = exceptionDetail.Priority;
            if (String.IsNullOrEmpty(userAlertMessage))
            {
                _customExceptionUserDefinedMessage = exceptionDetail.DefaultErrorMessage;
            }
            else
            {
                _customExceptionUserDefinedMessage = userAlertMessage;
            }
            if (ex != null)
            {
                _customExceptionSystemMessage = ex.Message;
            }
            else
            {
                _customExceptionSystemMessage = _customExceptionUserDefinedMessage;
            }
        }

        #endregion
    }
}