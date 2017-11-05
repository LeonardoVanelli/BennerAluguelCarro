using LocadoraCarro.DAO;
using LocadoraCarro.Models;
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
            List<Object> resultado = new List<object>();

            foreach (var carro in new CarroDAO().Lista())
            {
                var modelo = new ModeloDAO().BuscaPorId(carro.ModeloId);
                resultado.Add(new
                {
                    Id = carro.Id,
                    Modelo = modelo.Nome,
                    Marca = new MarcaDAO().BuscaPorId(modelo.MarcaId).Nome,
                    Preco = carro.PrecoDia
                });
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscaProtecoes()
        {
            var protecoes = new ProtecaoDAO().Lista();
            return Json(protecoes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AdicionaUsuario(string nome, string cpf, string email, string telefone, string login, string senha)
        {
            var cliente = new Cliente() { Nome = nome,
                                          Cpf = cpf,
                                          Email = email,
                                          Telefono = telefone,
                                          Login = login,
                                          Senha = senha};

            var dao = new ClienteDAO();
            dao.Adiciona(cliente);
            var usuarioCriado = dao.BuscaPorLoginSenha(login, senha);

            var data = new { id = usuarioCriado.Id };
            return Json(data);
        }

        public JsonResult Adiciona(string dTRetirada, string dTDevolucao, int idCliente, int idCarro, int idProtecao)
        {
            DateTime retirada = DateTime.Parse(dTRetirada);
            DateTime devolucao = DateTime.Parse(dTDevolucao);

            var carro = new CarroDAO().BuscaPorId(idCarro);
            var cliente = new ClienteDAO().BuscaPorId(idCliente);
            var protecao = new ProtecaoDAO().BuscaPorId(idProtecao);

            var aluguel = new Aluguel() { DataHoraRetirada = retirada ,
                                          DataHoraDevolucao = devolucao,
                                          Carro = carro,
                                          Cliente = cliente,
                                          Protecao = protecao};

            new AluguelDAO().Adiciona(aluguel);

            return Json(new { id = 12 });
        }
    }
}