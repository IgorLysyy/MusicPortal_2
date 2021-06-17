using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPortal_2.Controllers;
using MusicPortal_2.Interface;
using MusicPortal_2.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
namespace MusicPortal_2UnitTesting
{
    [TestClass]
    public class HomeControllerTests
    {
     
      
        [TestInitialize]
        public void SetupContext()
        {
       
        }
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            var mock = new Mock<IRepository<Sound>>();
            mock.Setup(q=>q.GetObjectList()).Returns(new List<Sound>());
            HomeController homeController = new HomeController(mock.Object);
            ViewResult result = homeController.Index() as ViewResult;
            Assert.IsNotNull(result.Model);
        }
        [TestMethod]
        public void ShowSoundViewResultNotNull()
        {
            var mock = new Mock<IRepository<Sound>>();
            mock.Setup(q => q.GetObject(1)).Returns(new Sound());
            HomeController homeController = new HomeController(mock.Object);
            ViewResult result = homeController.Index() as ViewResult;
            Assert.IsNotNull(result.Model);
        }

    }
}
