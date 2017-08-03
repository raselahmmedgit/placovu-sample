using System.Web;
using System.Web.Mvc;

namespace lab.lightbootstrapapps
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
