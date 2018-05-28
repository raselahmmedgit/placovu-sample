using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace lab.SBThemeApps.Helpers
{
    public enum MessageType { info, warn, success, error }
    
    public enum RoleEnum : int
    {
        [Description("Super Admin")]
        SuperAdmin = 1,
        [Description("Admin")]
        Admin = 2,
        [Description("Employee")]
        Employee = 3,
        [Description("User")]
        User = 4
    }

    public enum UserEnum : int
    {
        [Description("Super Admin")]
        SuperAdmin = 1,
        [Description("Admin")]
        Admin = 2,
        [Description("Employee")]
        Employee = 3,
        [Description("User")]
        User = 4
    }

    public enum RightEnum : int
    {
        Add = 1,
        Edit = 2,
        Details = 3,
        Delete = 4,
        DeleteBulk = 5,
        Archive = 6,
        ArchiveBulk = 7,
        Remove = 8,
        RemoveBulk = 9,
        Assign = 10,
        Approve = 11,
        SendEmail = 12,
        SendEmailBulk = 13,
        SendSMS = 14,
        SendSMSBulk = 15,
        ImportExcel = 16,
        ImportCsv = 17,
        ExportExcel = 18,
        ExportCsv = 19,
        ImportVCard = 20,
        ExportVCard = 21,
        ExportVCardBulk = 22,
        Call = 23,
        Print = 24,
        Download = 25,
        Upload = 26
    }

    public enum ApplicationSettingEnum : int
    {
        PageSize = 1,
        Version = 2,
        CacheTimeout = 3,
        SessionTimeout = 4,
        SendEmailPerMinute = 5,
        SendSMSPerMinute = 6
    }

    public enum ApplicationInformationEnum : int
    {
        HeaderTitle = 1,
        HeaderText = 2,
        HeaderUrl = 3,
        MetaAuthor = 4,
        MetaKeywords = 5,
        MetaDescription = 6,
        FooterText = 7,
        FooterUrl = 8
    }

    public enum EmailTemplateCategoryEnum : int
    {
        [Description("Super Admin Template")]
        SuperAdminTemplate = 1,
        [Description("Admin Template")]
        AdminTemplate = 2
    }

    public enum SMSTemplateCategoryEnum : int
    {
        [Description("Super Admin Template")]
        SuperAdminTemplate = 1,
        [Description("Admin Template")]
        AdminTemplate = 2
    }

    public enum WidgetCategoryEnum : int
    {
        [Description("Super Admin Widget")]
        SuperAdminWidget = 1,
        [Description("Admin Widget")]
        AdminWidget = 2,
        [Description("User Widget")]
        UserWidget = 3
    }

    public enum DocumentInfoTypeEnum : int
    {
        [Description("Super Admin Type")]
        SuperAdminType = 1,
        [Description("Admin Type")]
        AdminType = 2,
        [Description("User Type")]
        UserType = 3
    }

    public static class EnumExtensions
    {
        public static string ToDescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
        public static string ToDisplayNameAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(
                typeof(DisplayAttribute), false);

            if (attributes.Length > 0) return attributes[0].Name;
            else return source.ToString();
        }
        public static DisplayAttribute ToDisplayAttr<T>(this T source)
        {
            var input = source.ToString();
            FieldInfo fi = source.GetType().GetField(input);

            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(
                typeof(DisplayAttribute), false);

            if (attributes.Length > 0) return attributes[0];
            else return new DisplayAttribute { Name = input, ShortName = input, Description = input };
        }
    }
}