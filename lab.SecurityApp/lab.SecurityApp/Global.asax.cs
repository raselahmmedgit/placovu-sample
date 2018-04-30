using lab.SecurityApp.Helpers;
using lab.SecurityApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace lab.SecurityApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootStrapper.Run();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            // Get the exception object.
            Exception exception = Server.GetLastError();
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            // Handle HTTP errors
            if (exception != null && exception.GetType() == typeof(HttpException))
            {

                ExceptionHelper.Manage(exception, true);

                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (exception.Message.Contains("NoCatch") || exception.Message.Contains("maxUrlLength"))
                { return; }

            }
            else
            {
                // Log the exception and notify system operators
                if (exception != null)
                {
                    ExceptionHelper.Manage(exception, true);
                }

                if (!HttpContext.Current.Request.Url.ToString().Contains("Error"))
                {

                    bool isAjaxRequest = string.Equals("XMLHttpRequest", Context.Request.Headers["x-requested-with"], StringComparison.OrdinalIgnoreCase);
                    HttpException httpException = exception as HttpException;
                    int httpExceptionCode = httpException.GetHttpCode();

                    if (isAjaxRequest)
                    {
                        Context.Response.ContentType = "application/json";
                        #region switch check httpExceptionCode

                        switch (httpExceptionCode)
                        {

                            case 401:
                                Context.Response.StatusCode = 401;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error401 }));
                                break;

                            case 403:
                                Context.Response.StatusCode = 403;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error403 }));
                                break;

                            case 404:
                                Context.Response.StatusCode = 404;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error404 }));
                                break;

                            case 405:
                                Context.Response.StatusCode = 405;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error405 }));
                                break;

                            case 406:
                                Context.Response.StatusCode = 406;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error406 }));
                                break;

                            case 408:
                                Context.Response.StatusCode = 408;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error408 }));
                                break;

                            case 412:
                                Context.Response.StatusCode = 412;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error412 }));
                                break;

                            case 500:
                                Context.Response.StatusCode = 500;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error500 }));
                                break;

                            case 501:
                                Context.Response.StatusCode = 501;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error501 }));
                                break;

                            case 502:
                                Context.Response.StatusCode = 502;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error502 }));
                                break;

                            default:
                                Context.Response.StatusCode = 401;
                                Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.ErrorCommon }));
                                break;

                        }//end switch

                        // Clear the error from the context
                        Context.ClearError();

                        #endregion
                    }
                    else {

                        #region switch check httpExceptionCode

                        switch (httpExceptionCode)
                        {

                            case 401:
                                Response.Redirect(urlHelper.Action("401", string.Empty, new { Area = string.Empty }));
                                break;

                            case 403:
                                Response.Redirect(urlHelper.Action("403", string.Empty, new { Area = string.Empty }));
                                break;

                            case 404:
                                Response.Redirect(urlHelper.Action("404", string.Empty, new { Area = string.Empty }));
                                break;

                            case 405:
                                Response.Redirect(urlHelper.Action("405", string.Empty, new { Area = string.Empty }));
                                break;

                            case 406:
                                Response.Redirect(urlHelper.Action("406", string.Empty, new { Area = string.Empty }));
                                break;

                            case 408:
                                Response.Redirect(urlHelper.Action("408", string.Empty, new { Area = string.Empty }));
                                break;

                            case 412:
                                Response.Redirect(urlHelper.Action("412", string.Empty, new { Area = string.Empty }));
                                break;

                            case 500:
                                Response.Redirect(urlHelper.Action("500", string.Empty, new { Area = string.Empty }));
                                break;

                            case 501:
                                Response.Redirect(urlHelper.Action("501", string.Empty, new { Area = string.Empty }));
                                break;

                            case 502:
                                Response.Redirect(urlHelper.Action("502", string.Empty, new { Area = string.Empty }));
                                break;

                            default:
                                Response.Redirect(urlHelper.Action("Error", string.Empty, new { Area = string.Empty }));
                                break;

                        }//end switch

                        #endregion
                    }

                }
            }

            
            // Clear the error from the server
            Server.ClearError();
        }
        protected void Application_End()
        {
            SessionHelper.CurrentSession.Clear();
        }

    }
}
