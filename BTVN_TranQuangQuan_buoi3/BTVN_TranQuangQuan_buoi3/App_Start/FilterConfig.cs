﻿using System.Web;
using System.Web.Mvc;

namespace BTVN_TranQuangQuan_buoi3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
