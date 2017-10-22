using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaelumEstoque.DAO
{
    public class ClassesDAO
    {
        public void Adiciona(Classe categoria)
        {
            using (var context = new EstoqueContext())
            {
                context.Classes.Add(categoria);
                context.SaveChanges();
            }
        }

        public IList<Classe> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Classes.ToList();
            }
        }

        public Classe BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Classes.Find(id);
            }
        }

        public void Atualiza(Classe categoria)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}