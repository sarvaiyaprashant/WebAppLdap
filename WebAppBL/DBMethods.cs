using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppBL
{
    public class DBMethods
    {
        public bool insertLoggedInUser(AuthenticatedUsers user)
        {
            using (var context = new DemoAppEntities())
            {
                context.AuthenticatedUsers.Add(user);
                context.SaveChanges();
                return true;
            }
        }

        public List<AuthenticatedUsers> GetAuthenticatedUsers()
        {
            using (var context = new DemoAppEntities())
            {
                return context.AuthenticatedUsers.ToList();
            }
        }
    }
}
