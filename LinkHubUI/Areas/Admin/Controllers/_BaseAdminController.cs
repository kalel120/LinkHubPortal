using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace LinkHubUI.Areas.Admin.Controllers {
    public class _BaseAdminController : Controller {
        protected AdminBusiness objBs;

        public _BaseAdminController() {
            objBs = new AdminBusiness();
        }
    }
}