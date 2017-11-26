
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DAO.FuncaoDAO().
            var funcionarioLogado = new FuncionarioDAO().BuscaPorId(4);
            ViewBag.Funcionario = funcionarioLogado;

            return View();
        }
    }
}