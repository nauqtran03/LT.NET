﻿using System.Web;
using System.Web.Mvc;

namespace TranQuangQuan_071103
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
