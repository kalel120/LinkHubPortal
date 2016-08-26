using System;
using System.Web.Mvc;
using BLL;
using BOL;

namespace LinkHubUI.Areas.Admin.Controllers {
    public class CategoryController : Controller {
        private CategoryBs objBs;

        public CategoryController() {
            objBs = new CategoryBs();
        }

        // GET: Admin/Category
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category category) {
            try {
                if (ModelState.IsValid) {
                    objBs.InsertCategory(category);
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