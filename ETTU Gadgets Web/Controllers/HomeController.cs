using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETTU_Gadgets_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the ETTU Gadgets MVC Application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a trial application to boost my MVC skills.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "https://mysite.ettu.nl/reneo";

            return View();
        }
    }
}
