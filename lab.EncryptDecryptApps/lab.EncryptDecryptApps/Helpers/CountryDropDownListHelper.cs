using lab.EncryptDecryptApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace lab.EncryptDecryptApps.Helpers
{
    public static class CountryDropDownListHelper
    {
        public static IHtmlString CountryDropDownList(this HtmlHelper htmlHelper)
        {
            var result = String.Empty;

            CountryCacheHelper _countryCacheHelper = new CountryCacheHelper();

            var countryList = _countryCacheHelper.GetCountries;

            foreach (var country in countryList)
            {
                
            }

            return MvcHtmlString.Create(result);
        }
    }
}