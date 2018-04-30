using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab.SecurityApp.Controllers
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
        [Route("401")]
        public ActionResult Unauthorized()
        {
            return View();
        }

        // GET: 403 – Forbidden
        [Route("403")]
        public ActionResult Forbidden()
        {
            return View();
        }

        // GET: 404 – Not Found
        [Route("404")]
        public ActionResult NotFound()
        {
            return View();
        }

        // GET: 405 – Method Not Allowed
        [Route("405")]
        public ActionResult MethodNotAllowed()
        {
            return View();
        }

        // GET: 406 – Not Acceptable
        [Route("406")]
        public ActionResult NotAcceptable()
        {
            return View();
        }

        // GET: 408 - Request Timeout
        [Route("408")]
        public ActionResult RequestTimeout()
        {
            return View();
        }

        // GET: 412 – Precondition Failed
        [Route("412")]
        public ActionResult PreconditionFailed()
        {
            return View();
        }

        // GET: 500 – Internal Server Error
        [Route("500")]
        public ActionResult InternalServerError()
        {
            return View();
        }

        // GET: 501 – Not Implemented
        [Route("501")]
        public ActionResult NotImplemented()
        {
            return View();
        }

        // GET: 502 – Bad Gateway
        [Route("502")]
        public ActionResult BadGateway()
        {
            return View();
        }
    }
}
