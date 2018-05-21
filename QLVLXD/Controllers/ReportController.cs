using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLVLXD.Controllers
{
    public class ReportController : SecurityController
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
    }
}