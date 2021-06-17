using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MusicPortal_2.Controllers;
using MusicPortal_2.Interface;
using MusicPortal_2.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MusicPortal_2UnitTesting
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void RegistrationViewResultNotNull()
        {
            UserController userController = new UserController();
            ViewResult result = userController.Registration() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void LoginViewResultNotNull()
        {
            UserController userController = new UserController();
            var result = (RedirectToRouteResult)userController.Logout();

            result.RouteValues["Action"].Equals("Index");
            result.RouteValues["Controller"].Equals("Home");

            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
        }
        [TestMethod]
        public void RegistrationHttpTesting()
        {

            var mock = new Mock<IRepository<UserAccount>>();          
            UserAccount comp = new UserAccount();       
            UserController controller = new UserController(mock.Object);
            // act
            RedirectToRouteResult result = controller.Registration(comp) as RedirectToRouteResult;
            // assert
            mock.Verify(a => a.Attach(comp));
            mock.Verify(a => a.CreateObject(comp));
            mock.Verify(a => a.Save());

        }
    }
}
