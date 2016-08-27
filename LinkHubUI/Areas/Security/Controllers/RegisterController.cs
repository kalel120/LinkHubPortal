using System;
using System.Web.Mvc;
using BOL;

namespace LinkHubUI.Areas.Security.Controllers {
    public class RegisterController : _BaseSecurityController {
        // GET: Security/Register
        public ActionResult Index() {
            return View();
        }

        public ActionResult Create(tbl_User objUser) {
            try {
                if (ModelState.IsValid) {
                    objUser.Role = "U";
                    objBs.UserBusiness.InsertUser(objUser);
                    TempData["Msg"] = "Inserted Succesfully ";
                    return RedirectToAction("Index");
                }
                return View("Index");
            }
            catch (Exception exception) {
                TempData["Msg"] = "Failed! "+ exception;
                return RedirectToAction("Index");
            }
        }
    }
}