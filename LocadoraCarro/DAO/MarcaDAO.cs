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
    }
}