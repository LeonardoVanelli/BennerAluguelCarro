using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class CarroController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            CarrosDAO dao = new CarrosDAO();
            IList<Carro> carros = dao.Lista();
            ViewBag.Carros = carros;
            return View();        
        }

        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adiciona(Carro carro)
        {
            var dao = new CarrosDAO();
            dao.Adiciona(carro);

            return RedirectToAction("Index", "Carro");
        }
    }
}