using System.Web;
using System.Web.Mvc;

namespace FINAL_PROJECT_Tome_Books_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
