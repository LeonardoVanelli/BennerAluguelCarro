using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.DAO
{
    public class MarcaDAO
    {
        public IList<Marca> Lista()
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Marcas.ToList();
            }
        }
        public void Adiciona(Marca marca)
        {
            using (var context = new LocadoraContext())
            {
                context.Marcas.Add(marca);
                context.SaveChanges();
            }
        }

        public void Remove(Marca marca)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(marca).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
        public Marca BuscaPorId(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Marcas.Find(id);
            }
        }
    }
}