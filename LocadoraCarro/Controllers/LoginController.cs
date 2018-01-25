using LocadoraCarro.DAO;
using LocadoraCarro.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [JaEstaLogato]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            var daoCliente = new ClienteDAO();
            var daoFuncionario = new FuncionarioDAO();
            var usuario = daoCliente.BuscaPorLoginSenha(login, senha);            
            var funcioanrio = daoFuncionario.BuscaPorLoginSenha(login, senha);

            new AluguelDAO().ReservasParaHoje(7);

            if (usuario != null)
            {
                Session["clienteLogado"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else if (funcioanrio != null)
            {               
                Session["funcionarioLogado"] = funcioanrio;
                return RedirectToAction("Index", "Home");                
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        public JsonResult autenticaAluguel(string login, string senha)
        {
            var dao = new ClienteDAO();
            var usuario = dao.BuscaPorLoginSenha(login, senha);

            if (usuario != null)
            {
                Session["clienteLogado"] = usuario;
                return Json(new { id = usuario.Id });             
            }            
            return Json(new { id = 0 });
        }
            
        public ActionResult Deslogar()
        {
            Session["funcionarioLogado"] = null;
            Session["clienteLogado"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult FalhaLogin()
        {
            return View();
        }
    }
}