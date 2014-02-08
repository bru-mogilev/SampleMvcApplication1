using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SampleMvcApplication1
{
    using System;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Debug.WriteLine("-> Method 'MvcApplication.Application_Start' was called.");
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            Debug.WriteLine("-> Method 'MvcApplication.Application_BeginRequest' was called.");
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            Debug.WriteLine("-> Method 'MvcApplication.Application_EndRequest' was called.");
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            Debug.WriteLine("-> Method 'MvcApplication.Session_Start' was called.");
        }

        protected void Session_End(Object sender, EventArgs e)
        {
            Debug.WriteLine("-> Method 'MvcApplication.Session_End' was called.");
        }

        protected void Application_Error()
        {
            Debug.WriteLine("-> Method 'MvcApplication.Application_Error' was called.");
        }

        protected void Application_End()
        {
            Debug.WriteLine("-> Method 'MvcApplication.Application_End' was called.");
        }
    }
}
