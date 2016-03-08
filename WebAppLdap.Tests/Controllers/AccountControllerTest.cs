using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebAppLdap.Controllers;
using WebAppLdap.Models;

namespace WebAppLdap.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        //[TestMethod]
        //public void LogOnTest1()
        //{
        //    AccountController controller = new AccountController();

        //    LoginModel logonModel = new LoginModel();
        //    logonModel.UserName = "test";
        //    logonModel.Password = "test1234";

            
        //    var result = controller.Login(logonModel) as ViewResult;

        //    Assert.AreEqual("Index", result.ViewName);
        //}

        [TestMethod]
        public void ShouldRedisplayViewWhenModelIsNotValid()
        {
            // Arrange        
            var model = new LoginModel() { UserName = "", Password = "" };
            var controller = new AccountController();
            controller.ModelState.AddModelError("key", "error message");
            // Act
            var result = controller.Login(model) as ViewResult;
            // Assert
            Assert.AreEqual(result.ViewName, "Login");
        }
    }
}
