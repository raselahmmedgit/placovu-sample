using System.Web.Mvc;

namespace rabapp.web.Areas.Leave
{
    public class LeaveAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Leave";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Leave_default",
                "Leave/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}