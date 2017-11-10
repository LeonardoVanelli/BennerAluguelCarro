using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.DAO
{
    public class ClienteDAO
    {
        public void Adiciona(Cliente cliente)
        {
            using (var context = new LocadoraContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        public void Remove(Cliente cliente)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(cliente).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Cliente> Lista()
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Clientes.ToList();
            }
        }

        public Cliente BuscaPorId(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Clientes.Find(id);
            }
        }

        public void Atualiza(Cliente cliente)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Cliente BuscaPorLoginSenha(string login, string senha)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Clientes.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            }
        }
    }
}