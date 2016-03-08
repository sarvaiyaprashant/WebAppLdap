using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppBL;
using WebAppLdap.Models;

namespace WebAppLdap.Controllers
{
    public class AccountController : Controller
    {
        DBMethods dbMethod = new DBMethods();
        // GET: Accoun
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ServiceReference1.Service1Client objRef = new ServiceReference1.Service1Client();
            var isauth = objRef.Authenticate(model.UserName, model.Password);
            if (isauth)
            {
                dbMethod.insertLoggedInUser(new AuthenticatedUsers()
                {
                    LoggedInTime = DateTime.Now,
                    Username = model.UserName
                });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
            return View();
        }
    }
}