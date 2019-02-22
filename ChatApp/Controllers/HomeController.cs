using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "hello, i am index ";
            return View("Index");
        }

        public ActionResult Chat()
        {
            ViewBag.Message = "hello, i am chat ";
            return View("ChatView");
        }

        public ActionResult About()
        {
            ViewBag.Message = "hello, i am about ";

            return View("About");
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "hello, i am contact ";

            //return View("Contact");
            return RedirectToAction("Index");
        }
    }
}