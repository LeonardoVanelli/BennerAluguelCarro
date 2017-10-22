using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaelumEstoque.DAO
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Carro> Carros { get; set; }

        public DbSet<Classe> Classes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Protecao> Protecoes { get; set; }


    }
}