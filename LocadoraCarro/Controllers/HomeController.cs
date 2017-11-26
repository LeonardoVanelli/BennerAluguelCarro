
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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["funcionarioLogado"] != null)
            {
                if (((Funcionario)(Session["funcionarioLogado"])).FuncaoId != 1)
                {
                    return RedirectToAction("AIndex");
                }
                else
                {
                    return RedirectToAction("AIndex");
                }
            }
            else
            {
                return View();
            }                              
        }
        [AutorizacaoFiltreFuncionario]
        public ActionResult AIndex()
        {
            var alugueis = new AluguelDAO().Lista();
            var numeroDeRetiradasHoje = 0;
            var numeroDeCancelados = 0;
            var numeroRetirados = 0;
            var numeroNaoRetirados = 0;
            foreach (var aluguel in alugueis)
            {
                if (aluguel.DataHoraRetirada.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    numeroDeRetiradasHoje++;
                    if (aluguel.StatusId == new StatusDAO().BuscaPorNome("Cancelado").Id)
                    {
                        numeroDeCancelados++;
                    }
                    if (aluguel.StatusId == new StatusDAO().BuscaPorNome("Retirado").Id)
                    {
                        numeroRetirados++;
                    }
                    if (aluguel.StatusId == new StatusDAO().BuscaPorNome("Nao Retirado").Id)
                    {
                        numeroNaoRetirados++;
                    }
                }
            }          
            ViewBag.NumeroRetiradas = numeroDeRetiradasHoje;
            ViewBag.numeroCancelados = numeroDeCancelados;
            ViewBag.NumerosRetirados = numeroRetirados;
            ViewBag.numeroNaoRetirados = numeroNaoRetirados;
            return View();
        }
    }
}