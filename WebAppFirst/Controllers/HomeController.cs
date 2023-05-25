using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Yhtiön perustietoja.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Yhteystiedot:";

            return View();
        }
        public ActionResult Map()
        {
            ViewBag.Message = "Saapumisohje:";

            return View();
        }
    }
}