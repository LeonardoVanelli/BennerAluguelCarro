using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    public class HomeClienteController : Controller
    {
        // GET: HomeCliente
        public ActionResult Index()
        {
            return View();
        }
    }
}