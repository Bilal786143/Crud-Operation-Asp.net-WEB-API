using System.Web;
using System.Web.Mvc;

namespace Crud_Operation_Asp.net_WEB_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
