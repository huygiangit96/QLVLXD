using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLVLXD.Controllers
{
    public class ComponentController : SecurityController
    {
        // GET: Component
        public ActionResult Employee()
        {
            return View("Employee");
        }
        public ActionResult Supplier()
        {
            return View("Supplier");
        }
        public ActionResult ConstructorTeam()
        {
            return View("Constructor");
        }
    }
}