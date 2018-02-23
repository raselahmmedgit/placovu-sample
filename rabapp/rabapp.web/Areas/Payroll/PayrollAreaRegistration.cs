using System.Web.Mvc;

namespace rabapp.web.Areas.Payroll
{
    public class PayrollAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Payroll";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Payroll_default",
                "Payroll/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}