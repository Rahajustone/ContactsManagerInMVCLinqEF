using ContactsManagerInMVCLinqEF.BO;
using ContactsManagerInMVCLinqEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ContactsManagerInMVCLinqEF.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        UserBO objuserBO = new UserBO();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (FormsAuthentication.Authenticate(model.UserName.Trim(), model.Password.Trim()))
                {
                    string adminDetails = "0" + "^" + "Admin" + "^" + "Admin";
                    HttpContext.User = new GenericPrincipal(new GenericIdentity(adminDetails), new string[] { adminDetails.Split('^')[2] });
                    FormsAuthentication.SetAuthCookie(adminDetails, model.RememberMe);
                    return RedirectToAction("Manage", "Country", new { area = "Admin" });
                }
                else
                {
                    UserDetail userData = objuserBO.AuthenticateUser(model.UserName,model.Password);
                    string user = "";
                    if(userData != null)
                    {
                        user = userData.PKUserId + "^" + userData.UserName + "^User";
                    }
                    HttpContext.User = new GenericPrincipal(new GenericIdentity(user), new string[] { user.Split('^')[2] });
                    if (!string.IsNullOrEmpty(user))
                    {
                        FormsAuthentication.SetAuthCookie(user, model.RememberMe);
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid User Name or Password");
                        return View();
                    }
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("LogOn");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserDetail user)
        {
            if (ModelState.IsValid)
            {
                objuserBO.InsertUser(user);
                return RedirectToAction("LogOn");
            }
            return View(user);
        }
    }
}
