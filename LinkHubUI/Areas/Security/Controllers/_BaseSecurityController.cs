using BLL;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers {
    public class _BaseSecurityController : Controller {
        protected AdminBusiness objBs;
        public _BaseSecurityController() {
            objBs = new AdminBusiness();
        }

    }
}