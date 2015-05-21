using System.Web;
using System.Web.Mvc;

namespace Eh_che_couch.ProjectWork.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
