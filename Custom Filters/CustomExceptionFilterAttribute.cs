using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ContactsManagerInMVCLinqEF.Custom_Filters
{
    public class CustomExceptionFilterAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                if (Helper.CurrentUserName=="Admin")
                {
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "~/Areas/Admin/Views/Shared/Error.cshtml",
                        MasterName = "~/Areas/Admin/Views/Shared/AdminLayout.cshtml",
                        ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    };
                    filterContext.ExceptionHandled = true;
                }
                else
                {
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        MasterName = "~/Views/Shared/_Layout.cshtml",
                        ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    };
                    filterContext.ExceptionHandled = true;
                }
            }
        }
    }
}