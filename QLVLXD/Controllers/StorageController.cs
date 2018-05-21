using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLVLXD.Controllers
{
    public class StorageController : Controller
    {
        // GET: Storage
        public ActionResult StockIn()
        {
            return View("Stockin");
        }
        public ActionResult StockOut()
        {
            return View("Stockout");
        }
    }
}