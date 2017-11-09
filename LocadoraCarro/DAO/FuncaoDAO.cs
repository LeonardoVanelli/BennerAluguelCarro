using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.DAO
{
    public class FuncaoDAO
    {
        public void Adiciona(Funcao funcao)
        {
            using (var context = new LocadoraContext())
            {
                context.Funcaos.Add(funcao);
                context.SaveChanges();
            }
        }

        public void Remove(Funcao funcao)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(funcao).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Funcao> Lista()
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Funcaos.ToList();
            }
        }

        public Funcao BuscaPorId(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Funcaos.Find(id);
            }
        }

        public void Atualiza(Funcao funcao)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(funcao).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}