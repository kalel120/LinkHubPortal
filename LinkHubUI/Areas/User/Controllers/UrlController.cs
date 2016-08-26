using System;
using System.Linq;
using System.Web.Mvc;
using BLL;
using BOL;

namespace LinkHubUI.Areas.User.Controllers {
    public class UrlController : Controller {
        private UrlBs objUrlBs;
        private CategoryBs objCategoryBs;
        private UserBs objUserBs;

        public UrlController() {
            objUserBs = new UserBs();
            objCategoryBs = new CategoryBs();
            objUrlBs = new UrlBs();
        }
        public ActionResult Index() {
            ViewBag.CategoryId = new SelectList(objCategoryBs.GetAllCategories().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objUserBs.GetAllUser().ToList(), "UserId", "UserEmail");
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Url objUrlForPost) {
            try {
                if(ModelState.IsValid) {
                    objUrlBs.Insert(objUrlForPost);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryId = new SelectList(objCategoryBs.GetAllCategories().ToList(), "CategoryId", "CategoryName");
                ViewBag.UserId = new SelectList(objUserBs.GetAllUser().ToList(), "UserId", "UserEmail");
                return View("Index");
            }
            catch(Exception exception) {
                TempData["Msg"] = "Failed" + exception;
                return RedirectToAction("Index");
                throw;
            }
        }
    }
}