using LocadoraCarro.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraCarro.Controllers
{
    public class AluguelController : Controller
    {
        // GET: Aluguel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }
        public JsonResult BuscaCarros()
        {
            var carros = new CarroDAO().Lista();

            List<Object> resultado = new List<object>();

            foreach (var carro in carros)
            {
                var modelo = new ModeloDAO().BuscaPorId(carro.ModeloId);
                resultado.Add(new
                {
                    Modelo = modelo.Nome,
                    Marca = new MarcaDAO().BuscaPorId(modelo.MarcaId).Nome,
                    Preco = carro.PrecoDia
                });

            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}