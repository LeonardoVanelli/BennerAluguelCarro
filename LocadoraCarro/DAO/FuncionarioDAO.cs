using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.DAO
{
    public class FuncionarioDAO
    {
        public void Adiciona(Funcionario funcionario)
        {
            using (var context = new LocadoraContext())
            {
                context.Funcionarios.Add(funcionario);
                context.SaveChanges();
            }
        }

        public void Remove(Funcionario funcionario)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(funcionario).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Funcionario> Lista()
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Funcionarios.ToList();
            }
        }

        public Funcionario BuscaPorId(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Funcionarios.Find(id);
            }
        }

        public void Atualiza(Funcionario funcionario)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(funcionario).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Funcionario BuscaPorLoginSenha(string login, string senha)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Funcionarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            }
        }
    }
}