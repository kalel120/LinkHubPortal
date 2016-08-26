using System;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    public class RegisterController : _BaseSecurityController
    {
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }

        private ActionResult View() {
            throw new NotImplementedException();
        }
    }
}