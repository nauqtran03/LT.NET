using System.Web;
using System.Web.Mvc;

namespace Tuan7_TranQuangQuan_21103100304
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
