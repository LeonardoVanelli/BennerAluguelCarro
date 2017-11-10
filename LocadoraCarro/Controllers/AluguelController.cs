﻿using LocadoraCarro.DAO;
using LocadoraCarro.Filtros;
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
        [AutorizacaoFilterCliente]
        public ActionResult Index()
        {
            IList<Aluguel> aluguel = new List<Aluguel>();
            Cliente cliente = (Cliente)(Session["clienteLogado"]);
            if (cliente != null)
            {
                aluguel = new AluguelDAO().ListaPorUsuario(cliente.Id);
            }
            return View(aluguel);
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
                                          Telefone = telefone,
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
            //cadastra aluguel
            DateTime retirada = DateTime.Parse(dTRetirada);
            DateTime devolucao = DateTime.Parse(dTDevolucao);

            var aluguel = new Aluguel() { DataHoraRetirada = retirada ,
                                          DataHoraDevolucao = devolucao,
                                          CarroId = idCarro,
                                          ClienteId = idCliente,
                                          ProtecaoId = idProtecao };

            new AluguelDAO().Adiciona(aluguel);

            return Json(aluguel);
        }
        public JsonResult RetornaConfirmacao(int idCliente, int idCarro, int idProtecao)
        {
            //cria json 
            var carro = new CarroDAO().BuscaPorId(idCarro);
            var modelo = new ModeloDAO().BuscaPorId(carro.ModeloId);
            var marca = new MarcaDAO().BuscaPorId(modelo.MarcaId);

            var protecao = new ProtecaoDAO().BuscaPorId(idProtecao);


            var JsonAluguel = new
            {
                Modelo = modelo.Nome,
                Marca = marca.Nome,
                PrecoCar = carro.PrecoDia,
                Protecao = protecao.Nome,
                PrecoProtecao = protecao.PrecoDia
            };

            return Json(JsonAluguel);
        }
    }
}