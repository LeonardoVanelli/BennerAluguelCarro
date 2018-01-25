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
    [AutorizacaoFiltreFuncionario]
    public class ProtecaoController : Controller
    {
        // GET: Protecao
        public ActionResult Index()
        {
            var dao = new ProtecaoDAO();
            return View(dao.Lista());
        }

        public ActionResult Adiciona(Protecao protecao)
        {
            var dao = new ProtecaoDAO();
            dao.Adiciona(protecao);
            return RedirectToAction("Index");
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Visualiza(int id)
        {
            var dao = new ProtecaoDAO();
            return View(dao.BuscaPorId(id));
        }

        public ActionResult Remove(int id)
        {
            var dao = new ProtecaoDAO();
            dao.Remove(dao.BuscaPorId(id));
            return RedirectToAction("Index");
        }

        public ActionResult RetornaProtecao()
        {
            var alugueis = new AluguelDAO().Lista();
            int[] status = new int[3];

            foreach (var aluguel in alugueis)
            {                
                switch (aluguel.ProtecaoId)
                {
                    case 1:
                        status[0]++;
                        break;
                    case 2:
                        status[1]++;
                        break;
                    case 3:
                        status[2]++;
                        break;                   
                }                
            }
            return Json(status);
        }
    }
}