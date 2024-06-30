using System.Web;
using System.Web.Mvc;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
