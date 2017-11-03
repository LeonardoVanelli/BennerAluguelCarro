using LocadoraCarro.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    public class AluguelController : Controller
    {
        // GET: Aluguel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }
        public ActionResult BuscaCarros()
        {
            var dao = new CarroDAO().Lista();
            return View();
        }
    }
}