using BLL;

namespace LinkHubUI.Areas.User.Controllers {
    public class _BaseUserController {
        protected AdminBusiness objBs;
        public _BaseUserController() {
            objBs = new AdminBusiness();
        }
    }
}