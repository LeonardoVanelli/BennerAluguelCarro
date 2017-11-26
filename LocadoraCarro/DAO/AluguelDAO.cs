using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.DAO
{
    public class AluguelDAO
    {
        public void Adiciona(Aluguel aluguel)
        {
            using (var context = new LocadoraContext())
            {
                context.Alugueis.Add(aluguel);
                context.SaveChanges();
            }
        }

        public void Remove(Aluguel aluguel)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(aluguel).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Aluguel> Lista()
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Alugueis.ToList();
            }
        }

        public IList<Aluguel> ListaPorCliente(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                IList<Aluguel> alugueis = new List<Aluguel>();
                var testar = contexto.Alugueis.ToList();
                foreach (var aluguel in testar)
                {
                    if (aluguel.ClienteId == id)
                    {
                        alugueis.Add(aluguel);
                    } 
                }
                return alugueis;
            }
        }

        public IList<Aluguel> ListaPorUsuario(int idCliente)
        {
            using (var contexto = new LocadoraContext())
            {
                IList<Aluguel> alugueis = new List<Aluguel>();
                foreach (var item in contexto.Alugueis)
                {
                    if (item.ClienteId == idCliente)
                    {
                        alugueis.Add(item);
                    }
                }
                return alugueis;
            }
        }

        public Aluguel BuscaPorId(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Alugueis.Find(id);
            }
        }

        public IList<Aluguel> BuscaPorIdCarro(int carroId)
        {
            using (var contexto = new LocadoraContext())
            {
                IList<Aluguel> alugueis = new List<Aluguel>();
                foreach (var item in contexto.Alugueis)
                {
                    if (item.CarroId == carroId)
                    {
                        alugueis.Add(item);
                    }
                }
                return alugueis;
            }
        }

        public void Atualiza(Aluguel aluguel)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(aluguel).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}