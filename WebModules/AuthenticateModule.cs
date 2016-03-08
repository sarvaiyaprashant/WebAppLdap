using System;
using System.Collections.Generic;
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
        }

        void OnAuthentication(object sender, EventArgs a)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpResponse response = application.Context.Response;

            WindowsIdentity identity =
               (WindowsIdentity)application.Context.User.Identity;

            LogUser(identity.Name);
        }

        private void LogUser(String name)
        {
            DBMethods dbMethods = new DBMethods();
            var allAuthUsers = dbMethods.GetAuthenticatedUsers().Select(c => c.Username).ToList();
            if (allAuthUsers.Contains(name))
            {

            }
        }

        public void Dispose()
        { }
    }
}
