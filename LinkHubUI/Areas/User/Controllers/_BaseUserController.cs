using System.Web.Mvc;
using BLL;

namespace LinkHubUI.Areas.User.Controllers {
    [Authorize(Roles = "A,U")]
    public class _BaseUserController : Controller {
        protected AdminBusiness objBs;
        public _BaseUserController() {
            objBs = new AdminBusiness();
        }
    }
}