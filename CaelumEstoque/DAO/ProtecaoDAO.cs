using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaelumEstoque.DAO
{
    public class ProtecaoDAO
    {
        public void Adiciona(Protecao protecao)
        {
            using (var context = new EstoqueContext())
            {
                context.Protecoes.Add(protecao);
                context.SaveChanges();
            }
        }

        public IList<Protecao> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Protecoes.ToList();
            }
        }

        public Protecao BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Protecoes.Include("Categoria")
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Protecao protecao)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(protecao).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}