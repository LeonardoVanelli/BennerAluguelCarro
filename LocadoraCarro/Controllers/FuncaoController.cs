using LocadoraCarro.DAO;
using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    public class FuncaoController : Controller
    {
        //GET: Funcao
        public ActionResult Index()
        {
            return View(new FuncaoDAO().Lista());
        }
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adiciona(Funcao funcao)
        {
            var dao = new FuncaoDAO();
            dao.Adiciona(funcao);

            return RedirectToAction("Index", "Funcao");
        }
        public ActionResult Visualiza(int id)
        {
            var dao = new FuncaoDAO();
            ViewBag.Funcao = dao.BuscaPorId(id);
            return View();
        }
        public ActionResult Remove(int id)
        {
            var dao = new FuncaoDAO();
            dao.Remove(dao.BuscaPorId(id));
            return RedirectToAction("Index");
        }
    }
}