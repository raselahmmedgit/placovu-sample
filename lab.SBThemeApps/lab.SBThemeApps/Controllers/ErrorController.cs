using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.SBThemeApps.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Common Error
        [Route("Error")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: 401 – Unauthorized
        [Route("Unauthorized")]
        public ActionResult Unauthorized()
        {
            return View();
        }

        // GET: 403 – Forbidden
        [Route("Forbidden")]
        public ActionResult Forbidden()
        {
            return View();
        }

        // GET: 404 – Not Found
        [Route("NotFound")]
        public ActionResult NotFound()
        {
            return View();
        }

        // GET: 405 – Method Not Allowed
        [Route("MethodNotAllowed")]
        public ActionResult MethodNotAllowed()
        {
            return View();
        }

        // GET: 406 – Not Acceptable
        [Route("NotAcceptable")]
        public ActionResult NotAcceptable()
        {
            return View();
        }

        // GET: 408 - Request Timeout
        [Route("RequestTimeout")]
        public ActionResult RequestTimeout()
        {
            return View();
        }

        // GET: 412 – Precondition Failed
        [Route("PreconditionFailed")]
        public ActionResult PreconditionFailed()
        {
            return View();
        }

        // GET: 500 – Internal Server Error
        [Route("InternalServerError")]
        public ActionResult InternalServerError()
        {
            return View();
        }

        // GET: 501 – Not Implemented
        [Route("NotImplemented")]
        public ActionResult NotImplemented()
        {
            return View();
        }

        // GET: 502 – Bad Gateway
        [Route("BadGateway")]
        public ActionResult BadGateway()
        {
            return View();
        }
    }
}
