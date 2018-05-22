using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLVLXD.Controllers
{
    public class HomeController : SecurityController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Err403()
        {
            return View("Err403");
        }
    }
}