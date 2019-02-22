using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatApp.Controllers;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;


namespace ChatApp.UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        //testowanie czy zwrocony widok jest poprawny
        
        [TestMethod]
        public void About_ReturnsRightView_ReturnsTrue()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;
            NUnit.Framework.Assert.AreEqual("About", result.ViewName);
        }

        // testowanie czy odpowiednie dane zostały przekazane do widoku
        [TestMethod]
        public void About_ReturnsRightData_ReturnsTrue()
        {
            HomeController controller = new HomeController();           
            ViewResult result = controller.About() as ViewResult;           
            ViewDataDictionary viewData = result.ViewData;
            NUnit.Framework.Assert.AreEqual("hello, i am about ", viewData["Message"]);
        }
        // czy widok nie jest nullem
        [TestMethod]
        public void About_IsNotNull_ReturnsTrue()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;
            NUnit.Framework.Assert.AreNotEqual(null, result.ViewName);
        }


        [TestMethod]
        public void Index_ReturnsRightView_ReturnsTrue()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            NUnit.Framework.Assert.AreEqual("Index", result.ViewName);
        }

     
        [TestMethod]
        public void Index_ReturnsRightData_ReturnsTrue()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            ViewDataDictionary viewData = result.ViewData;
            NUnit.Framework.Assert.AreEqual("hello, i am index ", viewData["Message"]);
        }

        [TestMethod]
        public void Index_IsNotNull_ReturnsTrue()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            NUnit.Framework.Assert.AreNotEqual(null, result.ViewName);
        }

        [TestMethod]
        public void Chat_ReturnsRightView_ReturnsTrue()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Chat() as ViewResult;
            NUnit.Framework.Assert.AreEqual("ChatView", result.ViewName);
        }

        
        [TestMethod]
        public void Chat_ReturnsRightData_ReturnsTrue()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Chat() as ViewResult;
            ViewDataDictionary viewData = result.ViewData;
            NUnit.Framework.Assert.AreEqual("hello, i am chat ", viewData["Message"]);
        }

        [TestMethod]
        public void Chat_IsNotNull_ReturnsTrue()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Chat() as ViewResult;
            NUnit.Framework.Assert.AreNotEqual(null, result.ViewName);
        }

        //[TestMethod]
        //public void Contact_ReturnsRightView_ReturnsTrue()
        //{
        //    HomeController controller = new HomeController();
        //    ViewResult result = controller.Contact() as ViewResult;
        //    NUnit.Framework.Assert.AreEqual("Contact", result.ViewName);
        //}


        //[TestMethod]
        //public void Contact_ReturnsRightData_ReturnsTrue()
        //{
        //    HomeController controller = new HomeController();
        //    ViewResult result = controller.Contact() as ViewResult;
        //    ViewDataDictionary viewData = result.ViewData;
        //    NUnit.Framework.Assert.AreEqual("hello, i am contact ", viewData["Message"]);
        //}

        // testowanie przekierowania

        [TestMethod]
        public void Contact_RedirectedToIndex_ReturnTrue()
        {
           
            HomeController controller = new HomeController();
            RedirectToRouteResult result = controller.Contact() as RedirectToRouteResult;
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        
    }
}
