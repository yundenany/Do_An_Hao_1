﻿using System.Web;
using System.Web.Mvc;

namespace Do_An_Hao_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
