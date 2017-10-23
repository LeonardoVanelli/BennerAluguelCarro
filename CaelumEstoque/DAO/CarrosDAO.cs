using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaelumEstoque.DAO
{
    public class CarrosDAO
    {
        public void Adiciona(Carro carro)
        {
            using (var context = new EstoqueContext())
            {
                context.Carros.Add(carro);
                context.SaveChanges();
            }
        }

        public IList<Carro> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Carros.Include("Classes").ToList();
            }
        }

        public Carro BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Carros.Include("Classes")
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Carro carro)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(carro).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}