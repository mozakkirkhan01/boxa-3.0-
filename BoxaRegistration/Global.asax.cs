using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace BoxaRegistration
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            LoadRoutes(RouteTable.Routes);
        }

        private void LoadRoutes(RouteCollection routeCollection)
        {
            routeCollection.MapPageRoute("", "home", "~/default.aspx");
            routeCollection.MapPageRoute("", "contact-us", "~/contact-us.aspx");
            routeCollection.MapPageRoute("", "terms-conditions", "~/terms-conditions.aspx");
            routeCollection.MapPageRoute("", "privacy-policy", "~/privacy-policy.aspx");
            routeCollection.MapPageRoute("", "refund-policy", "~/refund-policy.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}