using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    public class HomeFuncController : Controller
    {
        // GET: HomeFunc
        public ActionResult Index()
        {
            return View();
        }
    }
}