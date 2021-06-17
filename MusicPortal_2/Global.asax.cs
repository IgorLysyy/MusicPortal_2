using MusicPortal_2.DataBaseContext;
using MusicPortal_2.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MusicPortal_2
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutoFacConfig.ConfigureContainer();
            Database.SetInitializer(new MainDbInitialize());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
