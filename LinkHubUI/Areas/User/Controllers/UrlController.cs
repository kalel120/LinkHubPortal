using System;
using System.Linq;
using System.Web.Mvc;
using BOL;

namespace LinkHubUI.Areas.User.Controllers {
    public class UrlController : _BaseUserController {

        public ActionResult Index() {
            ViewBag.CategoryId = new SelectList(objBs.CategoryBusiness.GetAllCategories().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objBs.UserBusiness.GetAllUser().ToList(), "UserId", "UserEmail");
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Url objUrlForPost) {
            try {
                if(ModelState.IsValid) {
                    objBs.UrlBusiness.Insert(objUrlForPost);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryId = new SelectList(objBs.CategoryBusiness.GetAllCategories().ToList(), "CategoryId", "CategoryName");
                ViewBag.UserId = new SelectList(objBs.UserBusiness.GetAllUser().ToList(), "UserId", "UserEmail");
                return View("Index");
            }
            catch(Exception exception) {
                TempData["Msg"] = "Failed" + exception;
                return RedirectToAction("Index");
            }
        }
    }
}