using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HelloWorld(string name)
        {
            ViewBag.Message = "Hello from HelloWorld Action on Home Controller";

            Session["name"] = name;
            ViewBag.MyName = name + " from ViewBag";

            return View("HelloWorldWebForm");
        }
    }
}