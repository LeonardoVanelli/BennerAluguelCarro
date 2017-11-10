using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.DAO
{
    public class CarroDAO
    {
        public void Adiciona(Carro carro)
        {
            using (var context = new LocadoraContext())
            {
                context.Carros.Add(carro);
                context.SaveChanges();
            }
        }

        public void Remove(Carro carro)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(carro).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Carro> Lista()
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Carros.ToList();
            }
        }

        public Carro BuscaPorId(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Carros.Find(id);
            }
        }

        public void Atualiza(Carro carro)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(carro).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}