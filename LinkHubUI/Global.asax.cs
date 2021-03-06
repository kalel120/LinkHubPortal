﻿using System.Web.Mvc;
using System.Web.Routing;

namespace LinkHubUI {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Adding Global Filters
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
        }
    }
}
