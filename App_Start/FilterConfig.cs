﻿using ContactsManagerInMVCLinqEF.Custom_Filters;
using System.Web;
using System.Web.Mvc;

namespace ContactsManagerInMVCLinqEF
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}