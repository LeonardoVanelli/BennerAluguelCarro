using LocadoraCarro.DAO;
using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    public class ModeloController : Controller
    {
        // GET: Modelo
        public ActionResult Index()
        {
            var dao = new ModeloDAO();
            ViewBag.Modelos = dao.Lista();
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Modelo modelo)
        {
            var dao = new ModeloDAO();
            dao.Adiciona(modelo);

            return RedirectToAction("Index", "Modelo");        
        }
    }
}