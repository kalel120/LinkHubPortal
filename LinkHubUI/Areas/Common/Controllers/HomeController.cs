using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers {
    public class HomeController : _BaseCommonController {
        // GET: Common/Home
        public ActionResult Index() {
            return View();
        }
    }
}