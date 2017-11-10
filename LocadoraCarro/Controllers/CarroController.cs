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
            var dao = new CarroDAO();        
            return View(dao.Lista());
        }

        public ActionResult Form()
        {
            ViewBag.Classe = new ClasseDAO().Lista();
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
            ViewBag.Classe = new ClasseDAO().BuscaPorId(ViewBag.Carro.ClasseId);

            ViewBag.Marca = new MarcaDAO().BuscaPorId(ViewBag.Modelo.MarcaId);
            return View();
        }

        public ActionResult Remove(int id)
        {
            var dao = new CarroDAO();
            dao.Remove(dao.BuscaPorId(id));
            return RedirectToAction("Index");        }
    }
}