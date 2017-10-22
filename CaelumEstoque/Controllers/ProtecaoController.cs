using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class ProtecaoController : Controller
    {
        // GET: Protecao
        public ActionResult Index()
        {
            var dao = new ProtecaoDAO();
            IList<Protecao> protecoes = dao.Lista();
            ViewBag.Protecao = protecoes;
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Protecao protecao)
        {
            var dao = new ProtecaoDAO();
            dao.Adiciona(protecao);

            return RedirectToAction("Index", "Protecao");
        }
    }
}