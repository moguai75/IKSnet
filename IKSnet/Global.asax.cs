using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IKSnet.Controllers;

namespace IKSnet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Admin User und Rolle kreieren
            BenutzerRolleController benutzerrolle = new BenutzerRolleController();
            benutzerrolle.AddUserAndRole();

            // Nur autorisierte User haben Zugriff
            GlobalFilters.Filters.Add(new AuthorizeAttribute());

        }
    }
}
