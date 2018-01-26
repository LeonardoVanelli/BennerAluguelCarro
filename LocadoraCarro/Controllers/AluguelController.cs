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
    public class AluguelController : Controller
    {
        // GET: Aluguel
        [AutorizacaoFilterCliente]
        public ActionResult Index()
        {
            IList<Aluguel> alugueis = new List<Aluguel>();
            IList<Cliente> clientes = new List<Cliente>();
            IList<Status> status = new List<Status>();
            IList<Protecao> protecoes = new List<Protecao>();
            IList<Modelo> modelos = new List<Modelo>();
            IList<Carro> carros = new List<Carro>();

            Cliente cliente = (Cliente)(Session["clienteLogado"]);
            if (cliente != null)
            {
                alugueis = new AluguelDAO().ListaPorUsuario(cliente.Id);                
            } else if (Session["funcionarioLogado"] != null)
            {
                alugueis = new AluguelDAO().Lista();
                foreach (var aluguel in alugueis)
                {                    
                    clientes.Add( new ClienteDAO().BuscaPorId(aluguel.ClienteId) );                  
                }             
            }
            foreach (var aluguel in alugueis)
            {
                VerificaStatus(aluguel);
                status.Add(new StatusDAO().BuscaPorId(aluguel.StatusId));
                protecoes.Add(new ProtecaoDAO().BuscaPorId(aluguel.ProtecaoId));
                carros.Add(new CarroDAO().BuscaPorId(aluguel.CarroId));
            }
            foreach (var carro in carros)
            {
                modelos.Add(new ModeloDAO().BuscaPorId(carro.ModeloId));
            }

            ViewBag.Cliente = clientes;
            ViewBag.Status = status;
            ViewBag.Protecoes = protecoes;
            ViewBag.Carros = carros;
            ViewBag.Modelos = modelos;
            ViewBag.ListaStatus = new StatusDAO().Lista();            

            return View(alugueis);            
        }

        public void VerificaStatus(Aluguel aluguel)
        {
            var status = new StatusDAO().BuscaPorId(aluguel.StatusId);            
            if (status.Nome == "Reservado")
            {
                if (aluguel.DataHoraRetirada <= DateTime.Now)
                {                    
                    aluguel.StatusId = new StatusDAO().BuscaPorNome("Nao Retirado").Id;
                }
            } else if (status.Nome == "Retirado")
            {
                if (aluguel.DataHoraDevolucao <= DateTime.Now)
                {
                    aluguel.StatusId = new StatusDAO().BuscaPorNome("Atraso Na Devolucao").Id;
                }
            }
            new AluguelDAO().Atualiza(aluguel);
        }

        public ActionResult Form()
        {
            if (Session["clienteLogado"] != null)
                ViewBag.ClienteLogado = ( (Cliente)(Session["clienteLogado"]) ).Id;
            else ViewBag.ClienteLogado = 0;
                ViewBag.Classes = new ClasseDAO().Lista();                        

            return View();
        }

        public JsonResult BuscaCarros(string dataRetirada, string dataDevolucao)
        {
            var resultado = new List<object>();

            var DTretirada = DateTime.Parse(dataRetirada);
            var DTdevolucao = DateTime.Parse(dataDevolucao);

            var teste = DTdevolucao.ToString("MM/dd/yyyy HH:mm:ss");

            var carros = new CarroDAO().RetornaCarrosDisponiveisPorData(DTretirada, DTdevolucao);

            foreach (var carro in carros)
            {
                var modelo = new ModeloDAO().BuscaPorId(carro.ModeloId);
                resultado.Add(new
                {
                    DiasTotal = calculaTempoComCarro(DTretirada, DTdevolucao),
                    Id = carro.Id,
                    Modelo = modelo.Nome,
                    Marca = new MarcaDAO().BuscaPorId(modelo.MarcaId).Nome,
                    // Classe = new ClasseDAO().BuscaPorId(carro.ClasseId).Nome,
                    Preco = carro.PrecoDia,
                    Imagem = carro.Imagem
                });
            }                             
            return Json(resultado, JsonRequestBehavior.AllowGet);         
        }

        public int calculaTempoComCarro(DateTime retirada, DateTime devolucao)
        {
            var diasTotal = (devolucao - retirada).TotalDays;
            if (diasTotal == 0) return 1;
            else
                return Convert.ToInt32(diasTotal);
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

            var data = new { id = usuarioCriado.Id,
                             login = usuarioCriado.Login,
                             senha = usuarioCriado.Senha};
            return Json(data);
        }

        public JsonResult Adiciona(string dTRetirada, string dTDevolucao, int idCliente, int idCarro, int idProtecao)
        {
            //cadastra aluguel
            DateTime retirada = DateTime.Parse(dTRetirada);
            DateTime devolucao = DateTime.Parse(dTDevolucao);

            var status = new StatusDAO().BuscaPorNome("Reservado");

            var aluguel = new Aluguel() { DataHoraRetirada = retirada ,
                                          DataHoraDevolucao = devolucao,
                                          CarroId = idCarro,
                                          ClienteId = idCliente,
                                          ProtecaoId = idProtecao,                                          
                                          StatusId = status.Id };

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
                PrecoProtecao = protecao.PrecoDia,
                Imagem = carro.Imagem
            };

            return Json(JsonAluguel);
        }
        public JsonResult Remove(int id)
        {
            var daoAluguel = new AluguelDAO();
            var aluguel = daoAluguel.BuscaPorId(id);

            daoAluguel.Remove(aluguel);

            var daoCarro = new CarroDAO();
            var carro = daoCarro.BuscaPorId(aluguel.CarroId);
            daoCarro.Atualiza(carro);

            return Json(new { id = 1 });
        }
        public JsonResult StatusCancela(int id)
        {
            var daoAluguel = new AluguelDAO();
            var aluguel = daoAluguel.BuscaPorId(id);
            aluguel.StatusId = new StatusDAO().BuscaPorNome("Cancelado").Id;

            daoAluguel.Atualiza(aluguel);

            return Json(new { id = 1 });
        }

        public JsonResult StatusFinaliza(int id)
        {
            var daoAluguel = new AluguelDAO();
            var aluguel = daoAluguel.BuscaPorId(id);
            aluguel.StatusId = new StatusDAO().BuscaPorNome("Finalizado").Id;

            daoAluguel.Atualiza(aluguel);

            return Json(new { id = 1 });
        }

        public JsonResult StatusIniciar(int id)
        {
            var daoAluguel = new AluguelDAO();
            var aluguel = daoAluguel.BuscaPorId(id);
            aluguel.StatusId = new StatusDAO().BuscaPorNome("Retirado").Id;

            daoAluguel.Atualiza(aluguel);

            return Json(new { id = 1 });
        }

        public JsonResult RetornaStatus(int id)
        {
            int[] status = new int[6];
            IList<Aluguel> alugueis = new List<Aluguel>();
            if (id == 0)
            {
                alugueis = new AluguelDAO().Lista();
            }else
            {
                alugueis = new AluguelDAO().ListaPorCliente(id);
            }
            
            foreach (var aluguel in alugueis)
            {
                var statusAluguel = new StatusDAO().BuscaPorId(aluguel.StatusId);
                switch (statusAluguel.Nome)
                {
                    case "Reservado":
                        status[0]++;
                        break;
                    case "Cancelado":
                        status[1]++;
                        break;
                    case "Finalizado":
                        status[2]++;
                        break;
                    case "Retirado":
                        status[3]++;
                        break;
                    case "Nao Retirado":
                        status[4]++;
                        break;
                    case "Atraso Na Devolucao":
                        status[5]++;
                        break;
                }
            }
            return Json(status);
        }

        public JsonResult RetornaTodasProtecao()
        {
            var protecoes = new ProtecaoDAO().Lista();

            var resultado = new List<object>();
            foreach (var protecao in protecoes)
            {
                resultado.Add(new
                {
                    Id = protecao.Id,
                    Nome = protecao.Nome,
                    Descricao = protecao.Descricao,
                    PrecoDia = protecao.PrecoDia
                });
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}