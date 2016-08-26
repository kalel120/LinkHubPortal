using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers {
    public class LogInController : _BaseSecurityController {
        // GET: Security/LogIn
        public ActionResult Index() {
            return View();
        }
    }
}