using LocadoraCarro.DAO;
using LocadoraCarro.Filtros;
using LocadoraCarro.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    [AutorizacaoFiltreFuncionario]
    public class CarroController : Controller
    {
        // GET: Carro
        public ActionResult Index()
        {
            var modelos = new List<Modelo>();
            var carros = new CarroDAO().Lista();
            foreach (var carro in carros)
            {
                modelos.Add( new ModeloDAO().BuscaPorId(carro.ModeloId) );
            }
            ViewBag.Modelos = modelos;
            return View(carros);
        }

        public ActionResult Form()
        {            
            ViewBag.Modelo = new ModeloDAO().Lista();
            return View();
        }

        public ActionResult Adiciona(Carro carro)
        {
            var dao = new CarroDAO();
            dao.Adiciona(carro);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            var dao = new CarroDAO();
            ViewBag.Carro = dao.BuscaPorId(id);

            ViewBag.Modelo = new ModeloDAO().BuscaPorId(ViewBag.Carro.ModeloId);            

            ViewBag.Marca = new MarcaDAO().BuscaPorId(ViewBag.Modelo.MarcaId);
            return View();
        }

        public ActionResult Remove(int id)
        {
            var dao = new CarroDAO();
            dao.Remove(dao.BuscaPorId(id));
            return RedirectToAction("Index");
        }
    }
}