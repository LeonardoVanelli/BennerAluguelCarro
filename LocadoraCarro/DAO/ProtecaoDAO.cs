using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.DAO
{
    public class ProtecaoDAO
    {
        public void Adiciona(Protecao protecao)
        {
            using (var context = new LocadoraContext())
            {
                context.Protecoes.Add(protecao);
                context.SaveChanges();
            }
        }

        public void Remove(Protecao protecao)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(protecao).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Protecao> Lista()
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Protecoes.ToList();
            }
        }

        public Protecao BuscaPorId(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Protecoes.Find(id);
            }
        }

        public void Atualiza(Protecao protecao)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(protecao).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}