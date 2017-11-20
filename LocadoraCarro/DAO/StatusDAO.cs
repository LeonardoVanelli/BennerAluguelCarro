using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.DAO
{
    public class StatusDAO
    {
        public IList<Status> Lista()
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Statuos.ToList();
            }
        }

        public Status BuscaPorId(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Statuos.Find(id);
            }
        }

        public Status BuscaPorNome(string nome)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Statuos.FirstOrDefault(u => u.Nome == nome);
            }
        }
    }
}