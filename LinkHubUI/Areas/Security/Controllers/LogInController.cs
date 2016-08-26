using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    public class LogInController : _BaseSecurityController
    {
        // GET: Security/LogIn
        public ActionResult Index()
        {
            return View();
        }

        private ActionResult View() {
            throw new NotImplementedException();
        }
    }
}