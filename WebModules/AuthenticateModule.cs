using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppBL;

namespace WebModules
{
    public class AuthenticateModule : IHttpModule
    {

        private HttpApplication httpApp;

        public void Init(HttpApplication httpApp)
        {
            this.httpApp = httpApp;
            httpApp.AuthenticateRequest += new EventHandler(OnAuthentication);
            httpApp.BeginRequest += HttpApp_BeginRequest;
            httpApp.EndRequest += HttpApp_EndRequest;
        }

        private void HttpApp_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpResponse response = application.Context.Response;

            if (!application.Context.Request.RawUrl.Contains("Account/Login"))
            {
                if (application.Context.User != null)
                {
                    DBMethods dbMethods = new DBMethods();
                    var allAuthUsers = dbMethods.GetAuthenticatedUsers().Select(c => c.Username).ToList();
                    if (allAuthUsers.Contains(application.Context.User.Identity.Name))
                    {
                        // Logged in user - Authenticated
                    }
                }
                else
                    application.Context.Response.Redirect("http://localhost:54011/Account/Login");
            }
        }

        private void HttpApp_BeginRequest(object sender, EventArgs e)
        {
            
        }

        void OnAuthentication(object sender, EventArgs a)
        {

        }

        private void LogUser(String name)
        {
           
        }

        public void Dispose()
        { }
    }
}
