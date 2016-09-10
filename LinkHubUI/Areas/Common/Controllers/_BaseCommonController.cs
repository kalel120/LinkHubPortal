using System.Web.Mvc;
using BLL;

namespace LinkHubUI.Areas.Common.Controllers {
    public class _BaseCommonController : Controller {
        protected CommonBusiness objBs;
        public _BaseCommonController() {
            objBs = new CommonBusiness();
        }
    }
}