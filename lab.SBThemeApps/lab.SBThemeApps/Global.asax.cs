using lab.SBThemeApps.Helpers;
using lab.SBThemeApps.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace lab.SBThemeApps
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

            if (exception != null)
            {
                ExceptionHelper.Manage(exception, true);

                UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                bool isAjaxRequest = string.Equals("XMLHttpRequest", Context.Request.Headers["x-requested-with"], StringComparison.OrdinalIgnoreCase);
                // Handle HTTP errors
                if (exception.GetType() == typeof(HttpException))
                {
                    // The Complete Error Handling Example generates
                    // some errors using URLs with "NoCatch" in them;
                    // ignore these here to simulate what would happen
                    // if a global.asax handler were not implemented.
                    if (exception.Message.Contains("NoCatch") || exception.Message.Contains("maxUrlLength"))
                    { return; }

                    if (!HttpContext.Current.Request.Url.ToString().Contains("Error"))
                    {
                        HttpException httpException = exception as HttpException;
                        int httpExceptionCode = httpException.GetHttpCode();

                        if (isAjaxRequest)
                        {
                            Context.Response.ContentType = "application/json";
                            #region switch check httpExceptionCode

                            switch (httpExceptionCode)
                            {

                                case 400:
                                    Context.Response.StatusCode = 400;
                                    Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.Error400 }));
                                    break;

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
                                    Context.Response.StatusCode = 500;
                                    Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.ErrorCommon }));
                                    break;

                            }//end switch

                            // Clear the error from the context
                            Context.ClearError();

                            #endregion
                        }
                        else
                        {
                            #region switch check httpExceptionCode

                            switch (httpExceptionCode)
                            {
                                case 400:
                                    Response.Redirect(urlHelper.Action("NotFound", "Error", new { Area = string.Empty }));
                                    break;

                                case 401:
                                    Response.Redirect(urlHelper.Action("Unauthorized", "Error", new { Area = string.Empty }));
                                    break;

                                case 403:
                                    Response.Redirect(urlHelper.Action("Forbidden", "Error", new { Area = string.Empty }));
                                    break;

                                case 404:
                                    Response.Redirect(urlHelper.Action("NotFound", "Error", new { Area = string.Empty }));
                                    break;

                                case 405:
                                    Response.Redirect(urlHelper.Action("MethodNotAllowed", "Error", new { Area = string.Empty }));
                                    break;

                                case 406:
                                    Response.Redirect(urlHelper.Action("NotAcceptable", "Error", new { Area = string.Empty }));
                                    break;

                                case 408:
                                    Response.Redirect(urlHelper.Action("RequestTimeout", "Error", new { Area = string.Empty }));
                                    break;

                                case 412:
                                    Response.Redirect(urlHelper.Action("PreconditionFailed", "Error", new { Area = string.Empty }));
                                    break;

                                case 500:
                                    Response.Redirect(urlHelper.Action("InternalServerError", "Error", new { Area = string.Empty }));
                                    break;

                                case 501:
                                    Response.Redirect(urlHelper.Action("NotImplemented", "Error", new { Area = string.Empty }));
                                    break;

                                case 502:
                                    Response.Redirect(urlHelper.Action("BadGateway", "Error", new { Area = string.Empty }));
                                    break;

                                default:
                                    Response.Redirect(urlHelper.Action("Index", "Error", new { Area = string.Empty }));
                                    break;

                            }//end switch

                            #endregion
                        }

                    }

                }
                else
                {
                    if (isAjaxRequest)
                    {
                        Context.Response.ContentType = "application/json";

                        Context.Response.StatusCode = 500;
                        Context.Response.Write(new JavaScriptSerializer().Serialize(new { error = MessageConstantHelper.ErrorCommon }));

                        // Clear the error from the context
                        Context.ClearError();
                    }
                    else
                    {
                        Response.Redirect(urlHelper.Action("Index", "Error", new { Area = string.Empty }));
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
