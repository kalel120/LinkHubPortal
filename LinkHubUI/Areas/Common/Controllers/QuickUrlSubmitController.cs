using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using BOL;

namespace LinkHubUI.Areas.Common.Controllers {
    [AllowAnonymous]
    public class QuickUrlSubmitController : _BaseCommonController {
        public ActionResult Index() {
            ViewBag.CategoryId = new SelectList(objBs.CategoryBusiness.GetAllCategories().ToList(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(QuickUrlSubmitModel quickUrl)  {
            try {
                ModelState.Remove("QuickSubmitUser.ConfirmPassword");
                ModelState.Remove("QuickSubmitUser.Password");
                ModelState.Remove("QuickSubmitUrl.UrlDesc");
                if (ModelState.IsValid) {
                    objBs.InsertQuickUrl(quickUrl);
                    TempData["Msg"] = "Insert Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryId = new SelectList(objBs.CategoryBusiness.GetAllCategories().ToList(), "CategoryId", "CategoryName");
                return View("Index");
            }
            catch (DbEntityValidationException dbEx) {
                foreach (var validationErrors in dbEx.EntityValidationErrors) {
                    foreach (var validationError in validationErrors.ValidationErrors) {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                TempData["Msg"] = "Failed" + dbEx.Message;
                return RedirectToAction("Index");

            }
        }
    }
}