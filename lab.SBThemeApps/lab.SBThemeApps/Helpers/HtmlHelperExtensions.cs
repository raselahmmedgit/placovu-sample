using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace lab.SBThemeApps
{
    public static class HtmlHelperExtensions
    {
        #region Application Info

        public static IHtmlString RenderApplicationTitle(this HtmlHelper htmlHelper)
        {
            var strContent = "SB Apps";

            return MvcHtmlString.Create(strContent);
        }

        public static IHtmlString RenderApplicationHeader(this HtmlHelper htmlHelper)
        {
            var strContent = String.Empty;

            return MvcHtmlString.Create(strContent);
        }

        public static IHtmlString RenderApplicationFooter(this HtmlHelper htmlHelper)
        {
            var title = String.Empty;

            var viewDataTitle = htmlHelper.ViewContext.ViewData["Title"] == null ? null : htmlHelper.ViewContext.ViewData["Title"];
            if (viewDataTitle != null)
            {
                var tempTitle = viewDataTitle;
                title += tempTitle;

                htmlHelper.ViewContext.ViewData["Title"] = null;
            }

            return MvcHtmlString.Create(title);
        }

        public static IHtmlString RenderApplicationMetaAuthor(this HtmlHelper htmlHelper)
        {
            var strContent = string.Empty;

            return MvcHtmlString.Create(strContent);
        }

        public static IHtmlString RenderApplicationMetaKeywords(this HtmlHelper htmlHelper)
        {
            var strContent = string.Empty;

            return MvcHtmlString.Create(strContent);
        }

        public static IHtmlString RenderApplicationMetaDescription(this HtmlHelper htmlHelper)
        {
            var strContent = string.Empty;

            return MvcHtmlString.Create(strContent);
        }

        #endregion

        #region Breadcrumb

        public static IHtmlString RenderBreadcrumb(this HtmlHelper htmlHelper)
        {
            var strContent = String.Empty;

            var httpContext = HttpContext.Current;
            var httpContextBase = new HttpContextWrapper(httpContext);
            string areaName = httpContextBase.Request.RequestContext.RouteData.DataTokens.ContainsKey("area") ? httpContextBase.Request.RequestContext.RouteData.DataTokens["area"].ToString() : "";
            string controllerName = httpContextBase.Request.RequestContext.RouteData.Values["controller"].ToString();
            string actionName = httpContextBase.Request.RequestContext.RouteData.Values["action"].ToString();

            var headerTitle = controllerName;
            var breadcrumbUrl = "/" + areaName + "/" + controllerName + "/" + actionName;
            var breadcrumbControllerName = controllerName;
            var breadcrumbActionName = actionName;

            strContent += "<ol class='breadcrumb'>";
            strContent += "<li class='breadcrumb-item'><a href='" + breadcrumbUrl + "'><i class='fa fa-dashboard'></i> " + breadcrumbControllerName + "</a></li>";

            if (!breadcrumbActionName.Contains("Index"))
            {
                strContent += "<li class='breadcrumb-item active'>" + breadcrumbActionName + "</li>";
            }

            strContent += "</ol>";


            return MvcHtmlString.Create(strContent);
        }

        #endregion
    }
}