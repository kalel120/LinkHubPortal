using BLL;

namespace LinkHubUI.Areas.Security.Controllers {
    public class _BaseSecurityController {
        protected AdminBusiness objBs;
        public _BaseSecurityController() {
            objBs = new AdminBusiness();
        }

    }
}