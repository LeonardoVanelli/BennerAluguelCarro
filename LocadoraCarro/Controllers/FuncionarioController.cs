using LocadoraCarro.DAO;
using LocadoraCarro.Filtros;
using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    [AutorizacaoFiltreAdm]
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            return View( new FuncionarioDAO().Lista() );
        }
        public ActionResult Form()
        {
            ViewBag.Funcao = new FuncaoDAO().Lista();
            return View();
        }

        public ActionResult Adiciona(Funcionario funcionario)
        {
            var dao = new FuncionarioDAO();
            dao.Adiciona(funcionario);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            var funcionario = new FuncionarioDAO().BuscaPorId(id);
            ViewBag.Funcao = new FuncaoDAO().BuscaPorId(funcionario.FuncaoId);
            return View(funcionario);
        }

        public ActionResult Remove(int id)
        {
            var dao = new FuncionarioDAO();
            dao.Remove(dao.BuscaPorId(id));
            return RedirectToAction("Index");
        }
    }
}