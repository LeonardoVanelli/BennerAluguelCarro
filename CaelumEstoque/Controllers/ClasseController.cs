using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ClasseController : Controller
    {
        // GET: Classe
        public ActionResult Index()
        {
            var dao = new ClassesDAO();
            IList<Classe> classes = dao.Lista();
            ViewBag.Classe = classes;
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Classe classe)
        {
            var dao = new ClassesDAO();
            dao.Adiciona(classe);

            return RedirectToAction("Index", "Classe");
        }
    }
}