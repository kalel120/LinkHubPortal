using System;
using System.Web.Mvc;
using BOL;

namespace LinkHubUI.Areas.User.Controllers {
    public class UrlController : Controller {
        // GET: User/Url
        // This is for rendering the Index Page
        public ActionResult Index() {
            LinkHubDbEntities objDbEntities = new LinkHubDbEntities();
            ViewBag.CategoryId = new SelectList(objDbEntities.tbl_Category,"CategoryId","CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Url objUrlForPost) {
            throw new NotImplementedException();
        }
    }
}