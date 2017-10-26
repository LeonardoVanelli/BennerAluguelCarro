using LocadoraCarro.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    public class CarroController : Controller
    {
        // GET: Carro
        public ActionResult Index()
        {
            var dao = new CarroDAO();           
            return View(dao.Lista());
        }
    }
}