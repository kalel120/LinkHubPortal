using System;
using System.Web.Mvc;
using BOL;

namespace LinkHubUI.Areas.Admin.Controllers {
    public class CategoryController : _BaseAdminController {
        // GET: Admin/Category
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category category) {
            try {
                if (ModelState.IsValid) {
                    objBs.CategoryBusiness.InsertCategory(category);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                return View("Index");
            }
            catch (Exception ex) {
                TempData["Msg"] = "Failed!!" + ex;
                return RedirectToAction("Index");
            }
        }
    }
}