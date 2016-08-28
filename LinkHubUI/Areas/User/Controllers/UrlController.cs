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
                //Assigning default url to 'P' 
                objUrlForPost.IsApproved = "P";
                //Auto assign unique id to each URL posted by a user
                objUrlForPost.UserId = objBs.UserBusiness.GetAllUser().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;

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