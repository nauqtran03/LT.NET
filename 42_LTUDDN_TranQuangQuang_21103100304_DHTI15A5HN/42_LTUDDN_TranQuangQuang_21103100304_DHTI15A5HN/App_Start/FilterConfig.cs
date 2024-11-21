using System.Web;
using System.Web.Mvc;

namespace _42_LTUDDN_TranQuangQuang_21103100304_DHTI15A5HN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
