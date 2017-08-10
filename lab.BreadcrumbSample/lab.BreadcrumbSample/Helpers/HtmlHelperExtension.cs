using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.BreadcrumbSample
{
    public static class HtmlHelperExtension
    {
        #region Breadcrumb

        public static IHtmlString RenderBreadcrumb(this HtmlHelper htmlHelper)
        {
            var strContent = String.Empty;

            var httpContext = HttpContext.Current;
            var httpContextBase = new HttpContextWrapper(httpContext);
            string areaName = httpContextBase.Request.RequestContext.RouteData.DataTokens.ContainsKey("area") ? httpContextBase.Request.RequestContext.RouteData.DataTokens["area"].ToString() : "";
            string controllerName = httpContextBase.Request.RequestContext.RouteData.Values["controller"].ToString();
            string actionName = httpContextBase.Request.RequestContext.RouteData.Values["action"].ToString();

            var rawUrl = HttpContext.Current.Request.RawUrl;
            var originalString = HttpContext.Current.Request.Url.OriginalString;
            var absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;

            var breadcrumbUrl = "/" + areaName + "/" + controllerName + "/" + actionName;
            var breadcrumbControllerName = controllerName;
            var breadcrumbActionName = actionName;

            strContent += "<ul class='breadcrumb'>";

            strContent += "<li><a href='" + rawUrl + "'><i class='fa fa-dashboard'></i> " + breadcrumbControllerName + "</a></li>";
            strContent += "<li>" + breadcrumbActionName + "</li>";

            strContent += "</ul>";

            return MvcHtmlString.Create(strContent);
        }

        #endregion
    }
}