﻿using System.Web;
using System.Web.Mvc;

namespace EnsignLib.Examples.SimpleCustomBacking
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
