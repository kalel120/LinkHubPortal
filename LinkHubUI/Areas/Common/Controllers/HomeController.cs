using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers {
    [AllowAnonymous]
    public class HomeController : _BaseCommonController {
        // GET: Common/Home
        public ActionResult Index() {
            return View();
        }
    }
}