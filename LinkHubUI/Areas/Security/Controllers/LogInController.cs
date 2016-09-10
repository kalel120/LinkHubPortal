using System;
using System.Web.Mvc;
using System.Web.Security;
using BOL;

namespace LinkHubUI.Areas.Security.Controllers {
    [AllowAnonymous]
    public class LogInController : _BaseSecurityController {
        // GET: Security/LogIn
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(tbl_User objUser) {
            try {
                if (Membership.ValidateUser(objUser.UserEmail, objUser.Password)) {
                    FormsAuthentication.SetAuthCookie(objUser.UserEmail, false);
                    return RedirectToAction("Index", "Home", new { area = "Common"});
                }
                TempData["Msg"] = "Sign In Failed!!";
                return RedirectToAction("Index");
            }
            catch (Exception exception) {
                TempData["Msg"] = "Sign In Failed "+ exception;
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOut() {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "Home", new {area = "Common"});
        }
    }
}