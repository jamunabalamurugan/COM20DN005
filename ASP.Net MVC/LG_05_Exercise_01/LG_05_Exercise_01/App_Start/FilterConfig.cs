﻿using System.Web;
using System.Web.Mvc;

namespace LG_05_Exercise_01
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}