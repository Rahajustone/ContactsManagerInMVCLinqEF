using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsManagerInMVCLinqEF
{
    public class Helper
    {
        public static void ShowAlert(System.Web.UI.Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), DateTime.Now.ToString(), "alert(\"" + message + "\");", true);
        }
        public static int CurrentUserID
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.User.Identity.Name.Split('^')[0]);
            }
        }
        public static string CurrentUserRole
        {
            get
            {
                return HttpContext.Current.User.Identity.Name.Split('^')[2];
            }
        }
        public static string CurrentUserName
        {
            get
            {
                return HttpContext.Current.User.Identity.Name.Split('^')[1];
            }
        }
    }
}