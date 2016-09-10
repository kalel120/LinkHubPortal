using System.Web.Mvc;
using BLL;

namespace LinkHubUI.Areas.Admin.Controllers {
    public class AdminBaseController : Controller {
        protected AdminBusinessLogic objBusinessLogic;

        public AdminBaseController() {
            objBusinessLogic = new AdminBusinessLogic();
        }
    }
}